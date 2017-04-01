using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public interface IState
    {

        bool MoveToNextState { get; }

        Status ReadNext(char character);

        void Reset();

        List<IState> NextStates { get; }

        StateMachine Automata { get; }

        IState OnComplete();
    }

    public enum Status
    {
        Running,
        Success,
        Fail
    }
}
