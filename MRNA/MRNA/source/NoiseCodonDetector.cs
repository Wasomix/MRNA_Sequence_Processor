// This class is responsible for detecting noise codon, i.e. 2 or more stop codons

using System.Collections.Generic;

namespace MRNA.source
{
    public class NoiseCodonDetector
    {
        private const int C_NOISE_CODON_CONDITION = 1;
        private List<int> _positionGenesToRemove;

        public NoiseCodonDetector()
        {
            _positionGenesToRemove = new List<int>();
        }

        public void DetectAndRemoveNoiseFromGenes(ref List<SingleGene> multipleGenes)
        {
            DetectWhereThereIsNoise(in multipleGenes);
            RemoveGenes(ref multipleGenes);
        }

        private void DetectWhereThereIsNoise(in List<SingleGene> multipleGenes)
        {
            int currentPosition = 0;

            foreach (SingleGene singleGene in multipleGenes)
            {
                int numberOfElements = singleGene._multipleCodons.Count;

                if (numberOfElements == C_NOISE_CODON_CONDITION) 
                {
                    var codon = singleGene._multipleCodons[0];
                    var stopCodonTypes = StopCodonTypes.GetStopCodonTypes();
                    if (stopCodonTypes.Contains(codon.ToUpper()))
                    {
                        _positionGenesToRemove.Add(currentPosition);
                    }
                }
                currentPosition++;
            }
        }

        private void RemoveGenes(ref List<SingleGene> multipleGenes)
        {
            int numberOfNoise = _positionGenesToRemove.Count;
            int numberOfGenesRemoved = 0;

            for (int i = 0; i < numberOfNoise; i++)
            {
                int positionGeneToRemove = _positionGenesToRemove[i];
                multipleGenes.RemoveAt(positionGeneToRemove - numberOfGenesRemoved);
                numberOfGenesRemoved++;
            }
        }
    }
}
