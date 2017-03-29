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
            using (var textStream = File.OpenText("messagefile.txt"))
            {
                while (!textStream.EndOfStream)
                {
                    Console.Write((char)textStream.Read());
                }
            }

            Console.ReadKey();
        }
    }
}
