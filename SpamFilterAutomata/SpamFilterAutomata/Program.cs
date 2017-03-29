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
            var state = new DocState();

            using (var textStream = File.OpenText("messagefile.txt"))
            {
                while (!textStream.EndOfStream)
                {
                    var read = (char) textStream.Read();
                    Console.Write(read);
                    if (state.ReadNext(read))
                    {
                        if (state.MoveToNextState)
                        {
                            Console.WriteLine("Ready to go to next state");
                            Console.ReadKey();
                        }
                    }
                    else
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
