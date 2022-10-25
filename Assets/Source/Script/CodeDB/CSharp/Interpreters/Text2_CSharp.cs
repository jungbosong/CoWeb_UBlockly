using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace UBlockly
{   
    [CodeInterpreter(BlockType = "text2_text")]
    public class Text2_Text_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string value = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("", "", value);
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ntag", "", value, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;          
        }
    }
    // h1
    [CodeInterpreter(BlockType = "text2_h1")]
    public class Text2_H1_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {   
            string value = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<h1>", "</h1>", value);
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ctag", "h1", value, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;            
        }
    }
    // p
    [CodeInterpreter(BlockType = "text2_p")]
    public class Text2_P_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {   
            string value = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<p>", "</p>", value);
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ctag", "p", value, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;            
        }
    }
    // span
    [CodeInterpreter(BlockType = "text2_span")]
    public class Text2_Span_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {   
            string value = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<span>", "</span>", value);
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ctag", "span", value, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;            
        }
    }
    // b
    [CodeInterpreter(BlockType = "text2_b")]
    public class Text2_B_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {   
            string value = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<b >", "</b >", value);
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ctag", "b", value, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;                     
        }
    }
    // br
    [CodeInterpreter(BlockType = "text2_br")]
    public class Text2_Br_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string value = block.GetFieldValue("VALUE");
            HtmlCodeMaker.Instance.AddCode("<br>", "", "");
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("nctag", "br", "", "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;          
        }
    }
    // a
    [CodeInterpreter(BlockType = "text2_a")]
    public class Text2_A_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {           
            StringBuilder strBuilder = new StringBuilder(); 
            string property = block.GetFieldValue("PROPERTY");
           
            string value = block.GetFieldValue("VALUE");
            UnityEngine.Debug.Log("text2_a_TEXT: " + value);

            strBuilder.Append("<a href=\"");
            
            switch (property)
            {
                default:
                    property = "www.coweb1.com";
                    strBuilder.Append("www.coweb1.com");
                    break;
                    
                case "COWEB2":
                    property = "www.coweb2.com";
                    strBuilder.Append("www.coweb2.com");
                    break;
                    
                case "COWEB3":
                    property = "www.coweb3.com";
                    strBuilder.Append("www.coweb3.com");
                    break;
                    
                case "COWEB4":
                    property = "www.coweb4.com";
                    strBuilder.Append("www.coweb4.com");
                    break;
                    
                case "COWEB5":
                    property = "www.coweb5.com";
                    strBuilder.Append("www.coweb5.com");
                    break;
            }
            strBuilder.Append("\">");
            strBuilder.Append(value);
            strBuilder.Append("</a>");
            UnityEngine.Debug.Log("text2_a_result: " + strBuilder.ToString());
            HtmlCodeMaker.Instance.AddCode("", "", strBuilder.ToString());
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("cptag", "a", value, property);
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;
        }
    }
    // ul
    [CodeInterpreter(BlockType = "text2_ul")]
    public class Text2_Ul_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {   
            HtmlCodeMaker.Instance.AddCode("<ul>", "", "");
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ctag", "ul", "", "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "VALUE");
            yield return ctor;            
            HtmlCodeMaker.Instance.AddCode("", "</ul>", "");
        }
    }
     // li
    [CodeInterpreter(BlockType = "text2_li")]
    public class Text2_Li_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string value = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<li>", "</li>", value);
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("ctag", "li", value, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;          
        }
    }
    
}