using System;
using System.Collections.Generic;
using System.Text;

namespace MRNA.source
{
    class MrnaSequenceParserFactory
    {
        private IMrnaSequenceParser _iMrnaSequenceParserHandler;

        public IMrnaSequenceParser GetMrnaSequenceParser(in string MrnaSequenceParserType)
        {
            
            switch (MrnaSequenceParserType.ToUpper())
            {
                case "SINGLEGENE":
                    _iMrnaSequenceParserHandler = new MrnaSequenceParserSingleGenes();
                    break;
                case "MULTIPLEGENES":
                    _iMrnaSequenceParserHandler = new MrnaSequenceParserMultipleGenes();
                    break;
            }

            return _iMrnaSequenceParserHandler;
        }
    }
}
