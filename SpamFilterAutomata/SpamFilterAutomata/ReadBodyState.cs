using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    public class ReadBodyState :IState
    {
        public List<string> Expected { get; protected set; }
        public int CurrentIndex { get; protected set; }
        
        public List<string> Valid { get; protected set; }

        public bool failed { get; set; }

        public bool MoveToNextState { get; protected set; }

        public IState NextState { get; protected set; }

        public ReadBodyState(IState nextState)
        {
            CurrentIndex = 0;
            NextState = nextState;
            Expected = new List<string>()
            {
                "freeaccess",
                "freesoftware",
                "freevacation",
                "freetrials",
                "win",
                "wins",
                "winner",
                "winners",
                "winning",
                "winnings",
            };
            Valid = new List<string>(Expected);
        }

        public bool ReadNext(char character)
        {
            if (character == ' ')
                return true;

            if (character == '<')
            {
                MoveToNextState = true;
                return true;
            }

            List<int> removeIndexes = new List<int>();
            for (int cnt = 0; cnt < Valid.Count; cnt++)
            {
                if (Valid[cnt].Length <= CurrentIndex)
                {
                     removeIndexes.Add(cnt);
                    continue;
                }

                if (Valid[cnt][CurrentIndex] != character)
                {
                    removeIndexes.Add(cnt);
                    continue;
                }

            }

            for (int cnt = removeIndexes.Count - 1; cnt >= 0; cnt--)
            {
                Valid.RemoveAt(cnt);
            }

            CurrentIndex++;
            return Valid.Count > 0;
        }

        public void Reset()
        {
            CurrentIndex = 0;
            Valid = new List<string>(Expected);

        }

    }
} 
