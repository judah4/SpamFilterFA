using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public class StateMachine
    {
        public List<string> Spam { get; private set; }
        public string CurrentDoc { get; set; }

        public IState StartState { get; set; }
        public IState CurrentState { get; set; }

        public StateMachine()
        {
            Spam = new List<string>();
        }

        public void ReadNext(char character)
        {
            var status = CurrentState.ReadNext(character);
            if (status == Status.Running)
            {
                Console.WriteLine($"");
            }
        }


        public void NextState()
        {
            var nextState = CurrentState.OnComplete();
            if (nextState == null)
            {
                Console.WriteLine("No Next state!");
            }
        }
    }
}
