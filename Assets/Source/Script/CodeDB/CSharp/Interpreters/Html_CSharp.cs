using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace UBlockly
{   
    [CodeInterpreter(BlockType = "html_body")]
    public class Html_Body_Cmdtor : ValueCmdtor
    {
        protected override DataStruct Execute(Block block)
        {
            string value = block.GetFieldValue("TEXT");
            return new DataStruct(value);
        }
    }
    [CodeInterpreter(BlockType = "html_h1")]
    public class Html_H1_Cmdtor : ValueCmdtor
    {
        protected override DataStruct Execute(Block block)
        {
            string value = block.GetFieldValue("TEXT");
            return new DataStruct(value);
        }
    }
}