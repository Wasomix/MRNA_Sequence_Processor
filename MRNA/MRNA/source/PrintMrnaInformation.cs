// This class is responsible for printing everything related with the
// MRNA processed sequence.

using System;
using System.Collections.Generic;

namespace MRNA.source
{
    class PrintMrnaInformation
    {
        public void PrintInformationRelatedWithProcessedMrnaSequence(in string mrnaSequence,
                                                                     in List<MrnaGeneAndError> mrnaGenesAndErrors)
        {
            PrintMrnaSequence(in mrnaSequence);
            PrintGenesAndMessageError(in mrnaGenesAndErrors);
        }

        private void PrintMrnaSequence(in string mrnaSequence)
        {
            Console.WriteLine("Input mRNA sequence: " + mrnaSequence);
        }

        private void PrintGenesAndMessageError(in List<MrnaGeneAndError> mrnaGenesAndErrors)
        {
            foreach (MrnaGeneAndError oneGeneAndError in mrnaGenesAndErrors)
            {
                SingleGene singleGene = oneGeneAndError._singleGene;
                ErrorManager errorManager = oneGeneAndError._errorManagerHandler;
                PrintSingleGene(in singleGene);
                PrintMessageError(in errorManager);
            }
        }

        private void PrintSingleGene(in SingleGene oneGene)
        {
            string gene = "";
            foreach (string codon in oneGene._multipleCodons)
            {
                gene = gene + codon;
            }

            Console.WriteLine("Gene processed: " + gene);
        }

        private static void PrintMessageError(in ErrorManager errorManager)
        {
            errorManager.PrintMessageError();
        }
    }
}
