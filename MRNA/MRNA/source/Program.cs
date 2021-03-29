using MRNA.source;
using System;
using System.Collections.Generic;

namespace MRNA
{
    class Program
    {
        static private int C_FILE_CMD_ARGUMENT_POSITION = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program!");            

            if(IsThereAnyArgument(args.Length))
            {
                ReadEnteredMrnaSequence(in args);                
            }

            Console.WriteLine("End of program!");
        }

        private static bool IsThereAnyArgument(int numberOfArguments)
        {
            return numberOfArguments > 0;
        }

        private static void ReadEnteredMrnaSequence(in string[] args)
        {
            ReadMrnaSequenceAndProcessItFactory factory = new ReadMrnaSequenceAndProcessItFactory();
            IReadMrnaSequenceAndProcessIt iReadMrnaSequeceAndProcessItHandler =
                  factory.GetMrnaSequenceAndProcessIt(in args[C_FILE_CMD_ARGUMENT_POSITION-1]);
            if(iReadMrnaSequeceAndProcessItHandler != null)
            {
                iReadMrnaSequeceAndProcessItHandler.ReadMrnaSequenceAndProcessIt(in args);
            } else
            {
                Console.WriteLine("Either File or Cmd misspell. Please try again");
            }           
        }
    }
}
