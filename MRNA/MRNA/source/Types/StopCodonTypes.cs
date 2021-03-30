using System;
using System.Collections.Generic;
using System.Text;

namespace MRNA.source
{
    public static class StopCodonTypes
    {
        private static List<string> _stopCodonTypes = new List<string> { "UAG", "UGA", "UAA" };
        
        public static List<string> GetStopCodonTypes()
        {
            return _stopCodonTypes;
        }

    }
}
