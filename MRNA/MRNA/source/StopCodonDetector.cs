// This class is responsible for detecting stop codon

using System.Collections.Generic;

namespace MRNA.source
{
    public static class StopCodonDetector
    {
        public static bool IsItStopCodon(string stopCodon)
        {
            var stopCodonTypes = StopCodonTypes.GetStopCodonTypes();
            return stopCodonTypes.Contains(stopCodon.ToUpper());
        }
    }
}
