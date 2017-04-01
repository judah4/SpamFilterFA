using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public class DocState : BaseState
    {
        public string Expected { get; protected set; }
        public int CurrentIndex { get; protected set; }

        public override bool MoveToNextState { get { return CurrentIndex >= Expected.Length; } }


        public DocState(StateMachine stateMachine) : base(stateMachine)
        {
            CurrentIndex = 0;
            Expected = "<DOC>";
            Automata = stateMachine;

        }

        public override Status ReadNext(char character)
        {
            if (Expected[CurrentIndex] != character)
                return Status.Fail;

            CurrentIndex++;

            if (!MoveToNextState)
            {
                return Status.Running;
            }

            return Status.Success;
        }

        public override void Reset()
        {
            CurrentIndex = 0;
        }

        public override IState OnComplete()
        {
            if (!MoveToNextState)
                return null;

            return NextStates[0];
        }
    }
}
