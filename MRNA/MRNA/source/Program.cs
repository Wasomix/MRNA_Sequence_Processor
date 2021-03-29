using MRNA.source;
using System;
using System.Collections.Generic;

namespace MRNA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program!");

            //if(IsThereAnyString(args.Length))
            {
                ProcessMrnaSequence(in args);
            }

            Console.WriteLine("End of program!");
        }

        private static bool IsThereAnyString(int numberOfArguments)
        {
            return numberOfArguments > 0;
        }

        private static void ProcessMrnaSequence(in string[] args)
        {
            int numberOfArguments = 2;//args.Length;
            Console.WriteLine("Number of arguments: " + numberOfArguments);

            for (int i = 0; i < numberOfArguments; i++)
            {
                string mrnaSequence = args[i];
                MrnaSequenceParserFactory mrnaFactory = new MrnaSequenceParserFactory();
                string multiple = "MultipleGenes";
                IMrnaSequenceParser mrnaSequenceParserHandler = mrnaFactory.GetMrnaSequenceParser(in multiple);
                List<MrnaGeneAndError> genes = mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
                /*PrintMrnaInformation printHanlder = new PrintMrnaInformation();
                printHanlder.PrintInformationRelatedWithProcessedMrnaSequence(
                    in mrnaSequence, in genes, in mrnaSequenceParserHandler.GetErrorManager());*/
            }
        }
    }
}
