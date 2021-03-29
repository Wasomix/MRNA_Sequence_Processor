// This is an interface for MrnaSequenceParser

using System.Collections.Generic;

namespace MRNA.source
{
    interface IMrnaSequenceParser
    {
        public List<MrnaGeneAndError> ProcessMrnaSequence(string mrnaSequence);
        public ErrorManager GetErrorManager();
    }
}
