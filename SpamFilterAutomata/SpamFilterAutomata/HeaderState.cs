using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public class HeaderState : IState
    {
        public string Expected { get; protected set; }
        public int CurrentIndex { get; protected set; }

        public bool MoveToNextState { get { return CurrentIndex >= Expected.Length; } }

        public IState NextState { get; protected set; }

        public StateMachine Automata { get; protected set; }

        public HeaderState(IState nextState, StateMachine stateMachine)
        {
            CurrentIndex = 0;
            Expected = "<DOCID>";
            NextState = nextState;
            Automata = stateMachine;

        }

        public bool ReadNext(char character)
        {
            if (Expected[CurrentIndex] != character)
                return false;

            CurrentIndex++;
            return true;
        }

        public void Reset()
        {
            CurrentIndex = 0;
        }
    }
}
