// This class is responsible for detecting errors in mRNA

namespace MRNA.source
{
    using System;
    using System.Collections.Generic;
    using ErrorTypes = TypeOfErrors.ErrorTypes;
    public class ErrorManager : ErrorInformation
    {

        public void UpdateErrorInformation(in SingleGeneParser singleGeneParserHandler)
        {
            UpdateErrorType(in singleGeneParserHandler);
        }

        private void PrintMessageError()
        {
            foreach(KeyValuePair<ErrorTypes, bool> errorFound in _errorType)
            {
                if(errorFound.Value)
                {
                    Console.WriteLine(_errorMessage[errorFound.Key]);
                }
            }
        }

        private void UpdateErrorType(in SingleGeneParser singleGeneParserHandler)
        {
            UpdateInvalidLengthError(singleGeneParserHandler.GetGeneLength());
            UpdateStopCodonError(singleGeneParserHandler.GetStopCodonFound());
            UpdateAllCharactersAreInvalid(singleGeneParserHandler.GetIfAllCharactersAreInvalid());
            UpdateNoError(in singleGeneParserHandler);
        }

        private void UpdateStopCodonError(bool stopCodonFound)
        {
            SetErrorType(ErrorTypes.NoStopCodon, stopCodonFound);
        }

        private void UpdateInvalidLengthError(int geneLength)
        {
            SetErrorType(ErrorTypes.InvalidStringLength, 
                         IsGeneLengthInValid(geneLength));
        }

        private void UpdateAllCharactersAreInvalid(bool allCharactersAreInvalid)
        {
            SetErrorType(ErrorTypes.InvalidInput, allCharactersAreInvalid);
        }

        private void UpdateNoError(in SingleGeneParser singleGeneParserHandler)
        {
            bool geneLengthError = IsGeneLengthInValid(singleGeneParserHandler.GetGeneLength());
            bool stopCodonError = singleGeneParserHandler.GetStopCodonFound();
            bool allCharsAreInvalidError = singleGeneParserHandler.GetIfAllCharactersAreInvalid();
            bool anyError = geneLengthError | stopCodonError | allCharsAreInvalidError;
            bool noError = !anyError;
            SetErrorType(ErrorTypes.NoError, noError);
        }

        private bool IsGeneLengthInValid(int geneLength)
        {
            return !IsGeneLengthValid(geneLength);
        }

        private bool IsGeneLengthValid(int geneLength)
        {
            return (geneLength % 3) == 0;
        }

        private void SetErrorPosition (int errorPosition)
        {
            _errorPosition = errorPosition;
        }
    }
}
