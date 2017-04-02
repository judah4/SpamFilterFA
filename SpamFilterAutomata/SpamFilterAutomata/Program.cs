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

           // IState state = new DocState(new HeaderState(new HeaderEndState(new ReadBodyState(null, stateMachine), stateMachine), stateMachine), stateMachine);

            using (var textStream = File.OpenText("messagefile.txt"))
            {
                while (!textStream.EndOfStream)
                {
                    var read = (char) textStream.Read();

                    
                }
            }

            Console.ReadKey();
        }
    }
}
