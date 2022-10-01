using System;
using System.Collections;
using System.Linq;

namespace UBlockly
{

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
