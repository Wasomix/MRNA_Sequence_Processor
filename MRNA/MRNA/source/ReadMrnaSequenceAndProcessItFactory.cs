// This is a factory class to decide which implementation to select

namespace MRNA.source
{
    class ReadMrnaSequenceAndProcessItFactory
    {
        private IReadMrnaSequenceAndProcessIt _iReadMrnaSequenceAndprocessItHandler;

        public IReadMrnaSequenceAndProcessIt GetMrnaSequenceAndProcessIt(in string mrnaSequenceSource)
        {
            switch (mrnaSequenceSource.ToUpper())
            {
                case "FILE":
                    _iReadMrnaSequenceAndprocessItHandler = new ReadMrnaSequenceAndProcessItFromFile();
                    break;
                case "CMD":
                    _iReadMrnaSequenceAndprocessItHandler = new ReadMrnaSequenceAndProcessItFromCmd();
                    break;
            }

            return _iReadMrnaSequenceAndprocessItHandler;
        }
    }
}
