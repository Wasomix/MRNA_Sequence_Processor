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

            if(IsThereAnyString(args.Length))
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
            int numberOfArguments = args.Length;
            Console.WriteLine("Number of arguments: " + numberOfArguments);

            for (int i = 0; i < numberOfArguments; i++)
            {
                string mrnaSequence = args[i];                
                MrnaSequenceParser mrnaSequenceParserHandler = new MrnaSequenceParser();
                List<SingleGene> genes = mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
                PrintMrnaSequence(in mrnaSequence);
                PrintGenes(in genes);
                PrintMessageError(in mrnaSequenceParserHandler);
            }
        }

        private static void PrintMrnaSequence(in string mrnaSequence)
        {
            Console.WriteLine("Input mRNA sequence: " + mrnaSequence);
        }

        private static void PrintGenes(in List<SingleGene> genes)
        {
            foreach (SingleGene oneGene in genes)
            {
                PrintSingleGene(in oneGene);
            }
        }

        private static void PrintSingleGene(in SingleGene oneGene)
        {
            string gene = "";
            foreach (string codon in oneGene._multipleCodons)
            {
                gene = gene + codon;
            }

            Console.WriteLine("Gene processed: " + gene);
        }
        
        private static void PrintMessageError(in MrnaSequenceParser mrnaSequenceParserHandler)
        {
            ErrorManager errorManager = mrnaSequenceParserHandler.GetErrorManager();
            errorManager.PrintMessageError();
        }
    }
}
