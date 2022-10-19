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
            HtmlCodeMaker.Instance.AddCode("NTAG", "", "", value);
            HtmlCodeMaker.Instance.ShowCode();
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
            HtmlCodeMaker.Instance.AddCode("CTAG", "<h1>", "</h1>", value);
            HtmlCodeMaker.Instance.ShowCode();
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
            HtmlCodeMaker.Instance.AddCode("CTAG", "<b >", "</b >", value);
            HtmlCodeMaker.Instance.ShowCode();
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;                     
            HtmlCodeMaker.Instance.AddCode("NTAG", "", "", "");
        }
    }
    // br
    [CodeInterpreter(BlockType = "text2_br")]
    public class Text2_Br_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string value = block.GetFieldValue("VALUE");
            HtmlCodeMaker.Instance.AddCode("TAG", "<br>", "", "");
            HtmlCodeMaker.Instance.ShowCode();
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
                    //result += "www.coweb1.com";
                    strBuilder.Append("www.coweb1.com");
                    break;
                    
                case "COWEB2":
                    //result += "www.coweb2.com";
                    strBuilder.Append("www.coweb2.com");
                    break;
                    
                case "COWEB3":
                    //result += "www.coweb3.com";
                    strBuilder.Append("www.coweb3.com");
                    break;
                    
                case "COWEB4":
                    //result += "www.coweb4.com";
                    strBuilder.Append("www.coweb4.com");
                    break;
                    
                case "COWEB5":
                    //result += "www.coweb5.com";
                    strBuilder.Append("www.coweb5.com");
                    break;
            }
            strBuilder.Append("\">");
            strBuilder.Append(value);
            strBuilder.Append("</a>");
            UnityEngine.Debug.Log("text2_a_result: " + strBuilder.ToString());
            HtmlCodeMaker.Instance.AddCode("NTAG", "", "", strBuilder.ToString());
            HtmlCodeMaker.Instance.ShowCode();
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;
        }
    }
}