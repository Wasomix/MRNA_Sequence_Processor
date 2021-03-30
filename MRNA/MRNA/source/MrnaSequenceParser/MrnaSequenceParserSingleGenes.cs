// This class is responsible for processing an mRNA sequence returning
// one gene at a time.

using System.Collections.Generic;


namespace MRNA.source
{
    class MrnaSequenceParserSingleGenes : MrnaSequenceParserBase, IMrnaSequenceParser
    {
        public MrnaSequenceParserSingleGenes()
        {
        }

        public void ProcessMrnaSequence(string mrnaSequence)
        {            
            ResetMrnaSequencePosition();

            if (IsNotMetadata(mrnaSequence))
            {
                ReadGenesFromMrnaSequence(mrnaSequence);
            }
        }

        public ErrorManager GetErrorManager()
        {
            return _errorManagerHandler;
        }

        private void ReadGenesFromMrnaSequence(string mrnaSequence)
        {
            int numberOfElements = mrnaSequence.Length;            

            while (EndOfMrnaSequenceNotReached(in numberOfElements))
            {
                ResetMrnaGenesAndErrorsList();
                var singleGene = ResetCodonListGetSingleGeneAndUpdatePositionInMrnaSequence(mrnaSequence.Substring(_mrnaSequencePosition));
                if (IsNotNoise(in singleGene))
                {
                    UpdateErrorInformationAddItAndAddNewGeneIfStopCodonFound(ref singleGene);
                    PrintInformationRelatedWithProcessedMrnaSequence(in mrnaSequence);
                }
            }
        }
    }
}
