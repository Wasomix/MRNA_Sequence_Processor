// This class is responsible for processing a whole mRNA sequence

using System;
using System.Collections.Generic;

namespace MRNA.source
{
    class MrnaSequenceParser
    {
        private SingleGeneParser _singleGeneParserHandler;
        private List<SingleGene> _multipleGenes;
        private MetadataDetector _metadataDetectorHandler;
        private NoiseCodonDetector _noiseCodonDetectorHandler;
        private ErrorManager _errorManagerHandler;
        private int _mrnaSequencePosition;       

        public MrnaSequenceParser()
        {
            _singleGeneParserHandler   = new SingleGeneParser();
            _multipleGenes = new List<SingleGene>();
            _metadataDetectorHandler   = new MetadataDetector();
            _noiseCodonDetectorHandler = new NoiseCodonDetector();
            _errorManagerHandler = new ErrorManager();
            ResetMrnaSequencePosition();            
        }

        private void ResetMrnaSequencePosition()
        {
            _mrnaSequencePosition = 0;
        }

        public List<SingleGene> ProcessMrnaSequence(string mrnaSequence)
        {
            ResetGenesList();
            ResetMrnaSequencePosition();

            if (IsNotMetadata(mrnaSequence))
            {
                ReadGenesFromMrnaSequence(mrnaSequence);
                DetectAndRemoveNoiseFromGenes();
                UpdateErrorInformation();
            }

            return _multipleGenes;
        }

        public ErrorManager GetErrorManager()
        {
            return _errorManagerHandler;
        }

        private void ReadGenesFromMrnaSequence(string mrnaSequence)
        {
            int numberOfElements = mrnaSequence.Length;

            while (EndOfMrnaSequenceNotReached(in numberOfElements))
            {
                var singleGene = ResetCodonListGetSingleGeneAndUpdatePositionInMrnaSequence(mrnaSequence.Substring(_mrnaSequencePosition)); // TODO: PUT IT IN SINGLEGENE CLASS
                AddNewGeneIfStopCodonFound(singleGene);             
            }
        }

        private void DetectAndRemoveNoiseFromGenes()
        {
            _noiseCodonDetectorHandler.DetectAndRemoveNoiseFromGenes(ref _multipleGenes);
        }

        private void UpdateErrorInformation()
        {
            _errorManagerHandler.UpdateErrorInformation(in _singleGeneParserHandler);       
        }

        private void PrintMessageError()
        {
            _errorManagerHandler.PrintMessageError();
        }

        private void ResetGenesList()
        {
            _multipleGenes.Clear();            
        }

        private SingleGene ResetCodonListGetSingleGeneAndUpdatePositionInMrnaSequence(string mrnaSequence)
        {
            SingleGene singleGene = ResetCodonsListAndGetSingleGene(mrnaSequence);
            UpdateMrnaSequencePosition();
            return singleGene;
        }

        private SingleGene ResetCodonsListAndGetSingleGene(string mrnaSequence)
        {
            return _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
        }

        private void UpdateMrnaSequencePosition()
        {
            var charsProcessed = _singleGeneParserHandler.GetNumberOfCharactersProcessed();
            _mrnaSequencePosition += charsProcessed;
        }

        private bool IsNotMetadata(string mrnaSequence)
        {
            return _metadataDetectorHandler.IsNotMetadata(mrnaSequence);
        }

        private void AddNewGeneIfStopCodonFound(SingleGene singleGene)
        {
            if (IsStopCodonFound())
            {
                AddNewGene(singleGene);
            }
        }   

        private void AddNewGene(SingleGene singleGene)
        {
            _multipleGenes.Add(new SingleGene(EList.Clone<string>(singleGene._multipleCodons)));
        }

        private bool IsStopCodonFound()
        {
            return _singleGeneParserHandler.GetStopCodonFound();
        }

        private bool EndOfMrnaSequenceNotReached(in int numberOfElements)
        {
            return !IsItEndOfMrnaSequenceReached(in numberOfElements);
        }

        private bool IsItEndOfMrnaSequenceReached(in int numberOfElements)
        {
            return _mrnaSequencePosition == numberOfElements;
        }
    }
}
