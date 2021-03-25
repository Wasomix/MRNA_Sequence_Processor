// This class is responsible for detecting noise codon, i.e. 2 or more stop codons

namespace MRNA.source
{
    public class NoiseCodonDetector
    {
        private const int C_NOISE_CODON_CONDITION = 1;

        public NoiseCodonDetector()
        {
            
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
