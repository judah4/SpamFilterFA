using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public class State
    {

        public Dictionary<State, StateTransfer> Transfers { get; set; }

        public State()
        {
            Transfers = new Dictionary<State, StateTransfer>();
        }

        public virtual Status ReadNext(char character)
        {
            return Status.Success;
        }

    }

    public enum Status
    {
        Running,
        Success,
        Failure
    }
}
