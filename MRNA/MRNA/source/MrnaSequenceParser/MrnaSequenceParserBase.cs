using System.Collections.Generic;

namespace MRNA.source
{
    class MrnaSequenceParserBase
    {
        protected SingleGeneParser _singleGeneParserHandler;
        protected List<MrnaGeneAndError> _mrnaGenesAndErrors;
        protected MetadataDetector _metadataDetectorHandler;
        protected NoiseCodonDetector _noiseCodonDetectorHandler;
        protected ErrorManager _errorManagerHandler;
        protected int _mrnaSequencePosition;

        protected MrnaSequenceParserBase()
        {
            _singleGeneParserHandler = new SingleGeneParser();
            _mrnaGenesAndErrors = new List<MrnaGeneAndError>();
            _metadataDetectorHandler = new MetadataDetector();
            _noiseCodonDetectorHandler = new NoiseCodonDetector();
            _errorManagerHandler = new ErrorManager();
            ResetMrnaSequencePosition();
        }

        protected void ResetMrnaSequencePosition()
        {
            _mrnaSequencePosition = 0;
        }

        protected bool IsNotNoise(in SingleGene singleGene)
        {
            return !IsThereNoiseInSingleGene(in singleGene);
        }

        private bool IsThereNoiseInSingleGene(in SingleGene singleGene)
        {
            return _noiseCodonDetectorHandler.IsThereNoiseInGene(in singleGene);
        }

        protected void UpdateErrorInformation()
        {
            _errorManagerHandler.UpdateErrorInformation(in _singleGeneParserHandler);
        }

        protected void PrintInformationRelatedWithProcessedMrnaSequence(in string mrnaSequence)
        {
            PrintMrnaInformation printInfoHandler = new PrintMrnaInformation();
            printInfoHandler.PrintInformationRelatedWithProcessedMrnaSequence(
                                      in mrnaSequence, in _mrnaGenesAndErrors);
        }

        protected void ResetMrnaGenesAndErrorsList()
        {
            _mrnaGenesAndErrors.Clear();
        }

        protected SingleGene ResetCodonListGetSingleGeneAndUpdatePositionInMrnaSequence(string mrnaSequence)
        {
            SingleGene singleGene = ResetCodonsListAndGetSingleGene(mrnaSequence);
            UpdateMrnaSequencePosition();
            return singleGene;
        }

        protected SingleGene ResetCodonsListAndGetSingleGene(string mrnaSequence)
        {
            return _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
        }

        protected void UpdateMrnaSequencePosition()
        {
            var charsProcessed = _singleGeneParserHandler.GetNumberOfCharactersProcessed();
            _mrnaSequencePosition += charsProcessed;
        }

        protected bool IsNotMetadata(string mrnaSequence)
        {
            return _metadataDetectorHandler.IsNotMetadata(mrnaSequence);
        }

        protected bool EndOfMrnaSequenceNotReached(in int numberOfElements)
        {
            return !IsItEndOfMrnaSequenceReached(in numberOfElements);
        }

        protected void UpdateErrorInformationAddItAndAddNewGeneIfStopCodonFound(ref SingleGene singleGene)
        {
            MrnaGeneAndError mrnaGeneAndError = new MrnaGeneAndError();
            UpdateErrorInformation();            
            CopyError(ref _errorManagerHandler, ref mrnaGeneAndError);            
            CopyGeneIfStopCodonFound(ref singleGene, ref mrnaGeneAndError);
            AddNewGeneAndError(in mrnaGeneAndError);            
        }

        private void CopyError(ref ErrorManager _errorManagerHandler, 
                               ref MrnaGeneAndError mrnaGeneAndError)
        {
            mrnaGeneAndError._errorManagerHandler = _errorManagerHandler;
        }

        private void CopyGeneIfStopCodonFound(ref SingleGene singleGene,
                                              ref MrnaGeneAndError mrnaGeneAndError)
        {
            if (IsStopCodonFound())
            {
                CopyGene(ref singleGene, ref mrnaGeneAndError);
            }
        }

        private void CopyGene(ref SingleGene singleGene, 
                              ref MrnaGeneAndError mrnaGeneAndError)
        {
            mrnaGeneAndError._singleGene = singleGene;
        }        

        private void AddNewGeneAndError(in MrnaGeneAndError mrnaGeneAndError)
        {
            _mrnaGenesAndErrors.Add(new MrnaGeneAndError(mrnaGeneAndError));
        }

        private bool IsStopCodonFound()
        {
            return _singleGeneParserHandler.GetStopCodonFound();
        }

        private bool IsItEndOfMrnaSequenceReached(in int numberOfElements)
        {
            return _mrnaSequencePosition == numberOfElements;
        }
    }
}
