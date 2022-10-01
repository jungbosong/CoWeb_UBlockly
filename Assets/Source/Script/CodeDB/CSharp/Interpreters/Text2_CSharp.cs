using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UBlockly
{   
    [CodeInterpreter(BlockType = "text2_h1")]
    public class Text2_H1_Cmdtor : EnumeratorCmdtor
    {
        protected override IEnumerator Execute(Block block)
        {   
            CmdEnumerator ctor = CSharp.Interpreter.ValueReturn(block, "VALUE", new DataStruct(""));
            yield return ctor;
            DataStruct input_VALUE = ctor.Data;

            ctor = CSharp.Interpreter.ValueReturn(block, "TEXT", new DataStruct(""));
            yield return ctor;
            DataStruct input_TEXT = ctor.Data;

            UnityEngine.Debug.Log("text2_h1_VALUE: " + input_VALUE.ToString());
            UnityEngine.Debug.Log("text2_h1_TEXT: " + input_TEXT.ToString());
        }
    }
    /*[CodeInterpreter(BlockType = "text2_h1")]
    public class Text_H1_Cmdtor : ValueCmdtor
    {
        protected override DataStruct Execute(Block block)
        {
            string value = block.GetFieldValue("TEXT");
            return new DataStruct(value);
        }
    }*/
    [CodeInterpreter(BlockType = "text2_text")]
    public class Text2_Text_Cmdtor : ValueCmdtor
    {
        protected override DataStruct Execute(Block block)
        {
            string value = block.GetFieldValue("TEXT");
            return new DataStruct(value);
        }
    }
}