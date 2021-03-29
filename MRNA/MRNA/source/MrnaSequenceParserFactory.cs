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
            
            switch (MrnaSequenceParserType)
            {
                case "SingleGene":
                    _iMrnaSequenceParserHandler = new MrnaSequenceParserSingleGenes();
                    break;
                case "MultipleGenes":
                    _iMrnaSequenceParserHandler = new MrnaSequenceParserMultipleGenes();
                    break;
            }

            return _iMrnaSequenceParserHandler;
        }
    }
}
