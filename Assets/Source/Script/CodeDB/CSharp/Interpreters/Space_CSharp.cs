using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace UBlockly
{
    [CodeInterpreter(BlockType = "space_html")]
    public class Space_HTML_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            HtmlCodeMaker.Instance.InitHtmlCode();
            JsonMaker.Instance.InitJsonData();

            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "HTML");
            yield return ctor;

            HtmlCodeMaker.Instance.AddCode("", "</html>","");
            HtmlCodeMaker.Instance.MakeHtmlFile();
            JsonMaker.Instance.MakeJsonFile();

            WebView.Instance.StartWebView();
        }
    }

    [CodeInterpreter(BlockType = "space")]
    public class Space_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            ItemListMutator mutator = block.Mutator as ItemListMutator;
            if (mutator == null)
                throw new Exception("Block \"space\" must have a mutater \"space_mutator\"");

            if (mutator.ItemCount > 0)
            {
                string[] elements = new string[mutator.ItemCount];
                for (int i = 0; i < mutator.ItemCount; i++)
                {
                    CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "ADD" + i, new DataStruct(""));
                    yield return ctor;
                }
            }
        }
    }
}
