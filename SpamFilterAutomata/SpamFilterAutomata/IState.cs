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

        bool ReadNext(char character);

        void Reset();

        IState NextState { get; }
    }
}
