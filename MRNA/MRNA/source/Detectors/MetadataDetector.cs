// This class is responsible for detecting metadata character in mRNA sequence

namespace MRNA.source
{
    class MetadataDetector
    {
        private const char C_METADATA_CHARACTER = '<';

        public bool IsNotMetadata(string mrnaSequence)
        {
            return !IsItMetadata(mrnaSequence);
        }

        private bool IsItMetadata(string mrnaSequence)
        {
            return mrnaSequence.StartsWith(C_METADATA_CHARACTER);
        }
    }
}
