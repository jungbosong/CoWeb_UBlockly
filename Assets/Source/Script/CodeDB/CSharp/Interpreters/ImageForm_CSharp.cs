using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UBlockly
{
    [CodeInterpreter(BlockType = "imageForm_img")]
    public class ImageForm_Img_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            StringBuilder strBuilder = new StringBuilder(); 
            string property = block.GetFieldValue("PROPERTY");
           
            string value = block.GetFieldValue("VALUE");
            UnityEngine.Debug.Log("imageForm_img_TEXT: " + value);

            strBuilder.Append("<img src=\"");
            
            switch (property)
            {
                default:
                    property = "image1.png";
                    strBuilder.Append("image1.png");
                    break;
                    
                case "IMAGE2":
                    property = "image2.png";
                    strBuilder.Append("image2.png");
                    break;
                    
                case "IMAGE3":
                    property = "https://cdn3.iconfinder.com/data/icons/user-interface-169/32/login-128.png";
                    strBuilder.Append("https://cdn3.iconfinder.com/data/icons/user-interface-169/32/login-128.png");
                    break;
                    
                case "IMAGE4":
                    property = "image4.png";
                    strBuilder.Append("image4.png");
                    break;
                    
                case "IMAGE5":
                    property = "image5.png";
                    strBuilder.Append("image5.png");
                    break;
            }
            strBuilder.Append("\">");
            strBuilder.Append(value);
            UnityEngine.Debug.Log("imageForm_img_result: " + strBuilder.ToString());
            HtmlCodeMaker.Instance.AddCode("", "", strBuilder.ToString());
            HtmlCodeMaker.Instance.ShowCode();
            JsonMaker.Instance.AddData("cptag", "img", value, property);
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "VALUE");
            yield return ctor;
        }
    }

    [CodeInterpreter(BlockType = "imageForm_form")]
    public class ImageForm_Form_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            HtmlCodeMaker.Instance.AddCode("<form>", "", "");
            JsonMaker.Instance.AddData("ctag", "form", "", "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "VALUE");
            yield return ctor;
            HtmlCodeMaker.Instance.AddCode("", "</form>", "");
            UnityEngine.Debug.Log("Form code: " + ctor.Data.ToString());
        }
    }

    [CodeInterpreter(BlockType = "imageForm_label")]
    public class ImageForm_Label_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string data = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<label>", "", data);
            JsonMaker.Instance.AddData("ctag", "label", data, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "VALUE");
            yield return ctor;
            HtmlCodeMaker.Instance.AddCode("", "</label>", "");
            HtmlCodeMaker.Instance.AddCode("<br>", "", "");
            UnityEngine.Debug.Log("label code: " + ctor.Data.ToString());
        }
    }

    [CodeInterpreter(BlockType = "imageForm_input")]
    public class ImageForm_Input_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string property = block.GetFieldValue("PROPERTY");
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<input type=\"");

            switch(property)
            {
                case "TEXT": 
                    strBuilder.Append("text\" ");
                    break;
                case "PASSWORD":
                    strBuilder.Append("password\" ");
                    break;
            }
            
            string placeHolder = block.GetFieldValue("PLACEHOLDER");
            strBuilder.Append("placeholder=\"");
            strBuilder.Append(placeHolder);
            strBuilder.Append("\"/>");

            HtmlCodeMaker.Instance.AddCode("", "", strBuilder.ToString());
            JsonMaker.Instance.AddData("cptag", "input", placeHolder, property);
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "PLACEHOLDER");
            yield return ctor;
        }
    }

    [CodeInterpreter(BlockType = "imageForm_button")]
    public class ImageForm_Button_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            string data = block.GetFieldValue("TEXT");
            HtmlCodeMaker.Instance.AddCode("<button>", "</button>", data);
            JsonMaker.Instance.AddData("ctag", "button", data, "");
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "TEXT");
            yield return ctor;
        }
    }
}
