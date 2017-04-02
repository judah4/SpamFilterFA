using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata.Transitions
{
    public class SpamTransfer
    {
        public string DocId { get; set; }

        public List<string> Valid { get; protected set; }

        public List<string> Expected { get; protected set; }
        public int CurrentIndex { get; protected set; }

        public bool Complete { get; set; }

        public SpamTransfer()
        {
            Expected = new List<string>()
            {
                "freeaccess",
                "freesoftware",
                "freevaction",
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

        public Status ReadNext(char character)
        {
            if (character == ' ')
                return Status.Running;

            if(Valid.Count < 1)
                Reset();

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
            if (Valid.Count < 1)
            {
                return Status.Running;
            }

            for (int cnt = 0; cnt < Valid.Count; cnt++)
            {
                if (Valid[cnt].Length == CurrentIndex)
                {
                    //found one!
                    Complete = true;
                    return Status.Success;
                }

            }
            return Status.Running;
        }

        public void Reset()
        {
            CurrentIndex = 0;
            Valid = new List<string>(Expected);
        }
    }
}
