// This class is responsible for processing a whole mRNA sequence

using System;
using System.Collections.Generic;

namespace MRNA.source
{
    class MrnaSequenceParserMultipleGenes : MrnaSequenceParserBase, IMrnaSequenceParser
    {   

        public MrnaSequenceParserMultipleGenes()
        {         
        }

        public List<MrnaGeneAndError> ProcessMrnaSequence(string mrnaSequence)
        {
            ResetMrnaGenesAndErrorsList();
            ResetMrnaSequencePosition();

            if (IsNotMetadata(mrnaSequence))
            {
                ReadGenesFromMrnaSequence(mrnaSequence);
				PrintInformationRelatedWithProcessedMrnaSequence(in mrnaSequence);
            }

            return _mrnaGenesAndErrors;
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
                var singleGene = ResetCodonListGetSingleGeneAndUpdatePositionInMrnaSequence(mrnaSequence.Substring(_mrnaSequencePosition)); // TODO: PUT IT IN SINGLEGENE CLASS
                if (IsNotNoise(in singleGene))
				{
					UpdateErrorInformationAddItAndAddNewGeneIfStopCodonFound(ref singleGene);
				}
            }
        }
    }
}
