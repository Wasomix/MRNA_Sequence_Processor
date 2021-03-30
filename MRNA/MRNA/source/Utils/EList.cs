// This class is an extension for list 

using System;
using System.Collections.Generic;
using System.Linq;

namespace MRNA.source
{
    static class EList
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
