// This class is responsible for containing mrna information to return.

namespace MRNA.source
{
    class MrnaGeneAndError
    {
        public SingleGene _singleGene { set; get; }
        public ErrorManager _errorManagerHandler { set; get; }

        public MrnaGeneAndError()
        {
            _singleGene = new SingleGene();
            _errorManagerHandler = new ErrorManager();
        }
        public MrnaGeneAndError(MrnaGeneAndError mrnaGeneAndError)
        {
            _singleGene = mrnaGeneAndError._singleGene;
            _errorManagerHandler = mrnaGeneAndError._errorManagerHandler;
        }
    }
}
