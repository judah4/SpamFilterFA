using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public class DocState : State
    {
        public string Expected { get; protected set; }
        public int CurrentIndex { get; protected set; }

        public DocState()
        {
            Expected = "<DOC>";
        }

        public override Status ReadNext(char character)
        {
            if (Expected[CurrentIndex] != character)
                return Status.Failure;

            CurrentIndex++;

            //if (!MoveToNextState)
            //{
            //    return Status.Running;
            //}

            return Status.Success;
        }
    }
}
