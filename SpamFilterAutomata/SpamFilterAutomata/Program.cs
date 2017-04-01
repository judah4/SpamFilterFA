using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamFilterAutomata
{
    class Program
    {
        static void Main(string[] args)
        {
            int curState = 0;
            var stateMachine = new StateMachine();
            var start = new DocState(stateMachine);
            stateMachine.CurrentState = start;
            stateMachine.StartState = start;

           // IState state = new DocState(new HeaderState(new HeaderEndState(new ReadBodyState(null, stateMachine), stateMachine), stateMachine), stateMachine);

            using (var textStream = File.OpenText("messagefile.txt"))
            {
                while (!textStream.EndOfStream)
                {
                    var read = (char) textStream.Read();
                    Console.Write(read);
                    var status = start.ReadNext(read);
                    if (status == Status.Success)
                    {
                        if (start.MoveToNextState)
                        {
                            Console.WriteLine("Ready to go to next state");
                            Console.ReadKey();
                            state = state.NextState;
                        }
                    }
                    else if(status == Status.Fail)
                    {
                        state.Reset();
                        //single backtrack revaluate
                        state.ReadNext(read);
                    }
                    
                }
            }

            Console.ReadKey();
        }
    }
}
