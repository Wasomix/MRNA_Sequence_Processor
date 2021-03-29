// This class is an interface to read mrna sequence either from command line
// or from file.

namespace MRNA.source
{
    interface IReadMrnaSequenceAndProcessIt
    {
        public void ReadMrnaSequenceAndProcessIt(in string[] args);
    }
}
