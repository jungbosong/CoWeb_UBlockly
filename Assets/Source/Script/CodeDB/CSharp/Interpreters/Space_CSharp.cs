using System;
using System.Collections;
using System.Linq;
using System.IO;
using UnityEngine;

namespace UBlockly
{
    [CodeInterpreter(BlockType = "space_html")]
    public class Space_HTML_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "HTML", new DataStruct(""));
            yield return ctor;
            DataStruct input = ctor.Data; 
            UnityEngine.Debug.Log("c# print: " + "<html>" + input.ToString() + "</html");
            MakeHtmlFile(Application.persistentDataPath + "/index.htm", "<html>" + input.ToString() + "</html");
            WebView.Instance.StartWebView();
        }
        public void MakeHtmlFile(string path, string data)
        {
            Debug.Log("called MakeHtmlFile");
            StreamWriter sw;
            FileStream fs;

            if(!File.Exists(path))
            {
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(data);
                sw.Flush();
                sw.Close();
                fs.Close();

            }
            else if(File.Exists(path))
            {
                File.Delete(path);
                MakeHtmlFile(path,data);
            }
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
            string result = String.Empty;
            if (mutator.ItemCount > 0)
            {
                string[] elements = new string[mutator.ItemCount];
                for (int i = 0; i < mutator.ItemCount; i++)
                {
                    CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "ADD" + i, new DataStruct(""));
                    yield return ctor;
                    elements[i] = ctor.Data.StringValue;
                }
                result = string.Join("", elements);
            }
            ReturnData(new DataStruct(result));
        }
    }
}
