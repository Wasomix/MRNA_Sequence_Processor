// This class is responsible for detecting stop codon

using System.Collections.Generic;

namespace MRNA.source
{
    public static class StopCodonDetector
    {
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
            var stopCodonTypes = StopCodonTypes.GetStopCodonTypes();
            return stopCodonTypes.Contains(stopCodon);
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
