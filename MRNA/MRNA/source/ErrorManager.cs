// This class is responsible for detecting errors in mRNA

namespace MRNA.source
{
    public class ErrorManager : ErrorInformation
    {

        public void UpdateErrorInformation(in SingleGeneParser singleGeneParserHandler)
        {
            UpdateErrorType(in singleGeneParserHandler);
        }

        public TypeOfErrors.ErrorTypes GetTypeOfError()
        {
            return GetErrorType();
        }

        private void UpdateErrorType(in SingleGeneParser singleGeneParserHandler)
        {
            int geneLength = singleGeneParserHandler.GetGeneLength();
            bool allCharactersAreInvalid = singleGeneParserHandler.GetIfAllCharacterAreInvalid();
            bool stopCodonFound = singleGeneParserHandler.GetStopCodonFound();
        }

        private void CheckIfNoStopCodonFound(bool stopCodonFound)
        {
            
        }

        private void SetErrorPosition (int errorPosition)
        {
            _errorPosition = errorPosition;
        }

        private void SetTypeOfError (TypeOfErrors.ErrorTypes errorType)
        {
            SetErrorType(errorType);
        }
    }
}
