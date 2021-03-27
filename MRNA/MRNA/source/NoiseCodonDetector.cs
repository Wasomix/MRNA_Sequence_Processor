// This class is responsible for detecting noise codon, i.e. 2 or more stop codons

using System.Collections.Generic;

namespace MRNA.source
{
    public class NoiseCodonDetector
    {
        private const int C_NOISE_CODON_CONDITION = 1;

        public NoiseCodonDetector()
        {
            
        }

        public void DetectAndRemoveNoiseFromGenes(ref List<SingleGene> multipleGenes)
        {
            List<int> positionGenesToRemove = new List<int>();
            int currentPosition = 0;

            // DetectWhereThereIsNoise();
            foreach (SingleGene singleGene in multipleGenes)
            {
                int numnberOfElements = singleGene._multipleCodons.Count;
                if(numnberOfElements == C_NOISE_CODON_CONDITION) // TODO: I have to check if it is stop codon
                {
                    var codon = singleGene._multipleCodons[0];
                    var stopCodonTypes = StopCodonTypes.GetStopCodonTypes();
                    if (stopCodonTypes.Contains(codon.ToUpper()))
                    {
                        positionGenesToRemove.Add(currentPosition);
                    }                    
                }
                currentPosition++;
            }

            // RemoveGenes();
            int numberOfNoise = positionGenesToRemove.Count;
            int numberOfGenesRemoved = 0;
            for(int i=0; i<numberOfNoise; i++)
            {
                int positionGeneToRemove = positionGenesToRemove[i];                
                multipleGenes.RemoveAt(positionGeneToRemove - numberOfGenesRemoved);
                numberOfGenesRemoved++;
            }
        }

        public bool CheckIfIsItNoiseCodonAndUpdateNoiseCounter()
        {
            bool isNoiseCodon = false;

            if(IsItNoiseCodon())
            {
                isNoiseCodon = true;
                StopCodonDetector.ResetStopCodonCounter();
            }

            return isNoiseCodon;
        }

        private bool IsItNoiseCodon()
        {
            return StopCodonDetector.GetStopCodonCounter() > C_NOISE_CODON_CONDITION;
        }
    }
}
