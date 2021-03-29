using System;
using System.Collections.Generic;
using System.Text;

namespace MRNA.source
{
    class ReadMrnaSequenceAndProcessItFromCmd : ReadMrnaSequenceAndProcessItBase, IReadMrnaSequenceAndProcessIt
    {
        public ReadMrnaSequenceAndProcessItFromCmd()
        {

        }

        public void ReadMrnaSequenceAndProcessIt(in string[] args)
        {
            int numberOfArguments = args.Length;
            Console.WriteLine("Number of arguments: " + numberOfArguments);
            SetMrnaSequenceParser(in args);

            for (int i = 1; i < numberOfArguments; i++)
            {
                string mrnaSequence = args[i];
                ProcessMrnaSequence(mrnaSequence);
            }
        }
    }
}
