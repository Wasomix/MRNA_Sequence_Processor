using System;
using System.Collections.Generic;
using System.Text;

namespace MRNA.source
{
    class ReadMrnaSequenceAndProcessItFromCmd : ReadMrnaSequenceAndProcessItBase, IReadMrnaSequenceAndProcessIt
    {
        private const int C_ARGUMENT_POSITION_FOR_FIRST_MRNA_SEQUENCE = 3;

        public ReadMrnaSequenceAndProcessItFromCmd()
        {

        }

        public void ReadMrnaSequenceAndProcessIt(in string[] args)
        {
            int numberOfArguments = args.Length;
            Console.WriteLine("Number of arguments: " + numberOfArguments);
            SetMrnaSequenceParser(in args);

            for (int i = C_ARGUMENT_POSITION_FOR_FIRST_MRNA_SEQUENCE-1; i < numberOfArguments; i++)
            {
                string mrnaSequence = args[i];
                ProcessMrnaSequence(mrnaSequence);
            }
        }
    }
}
