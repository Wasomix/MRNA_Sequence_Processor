// This class is responsible for detecting stop codon

using System.Collections.Generic;

namespace MRNA.source
{
    public static class StopCodonDetector
    {
        private static List<string> _stopCodonDetector = new List<string> { "UAG", "UGA", "UAA" };
        private static int _stopCodonCounter = 0;

        public static void ResetStopCodonCounter()
        {
            _stopCodonCounter = 0;
        }

        public static bool CheckIfItIsStopCodonAndUpdateStopCodonCounter(string stopCodon)
        {
            bool isStopCodon = false;

            if (IsItStopCodon(stopCodon.ToUpper()))
            {
                isStopCodon = true;
                IncreaseStopCodonCounter();
            }

            return isStopCodon;
        }

        private static bool IsItStopCodon(string stopCodon)
        {
            return _stopCodonDetector.Contains(stopCodon);
        }

        private static void IncreaseStopCodonCounter()
        {
            _stopCodonCounter++;
        }

        public static int GetStopCodonCounter()
        {
            return _stopCodonCounter;
        }
    }
}
