// This class is responsible for parsing mRNA sequence to get single gene

using System.Collections.Generic;


namespace MRNA.source
{
    class SingleGeneParser
    {
        private const int C_CODON_SIZE = 3;
        private bool _stopCodonFound;
        private int _amountOfCharactersProcessed;
        private SingleGene _singleGene;
        private ValidCharacterDetector _validCharacterDetectorHandler;        

        public SingleGeneParser()
        {
            _stopCodonFound = false;            
            _amountOfCharactersProcessed = 0;
            _singleGene = new SingleGene();
            _validCharacterDetectorHandler = new ValidCharacterDetector();
        }

        public SingleGene ResetCodonsListAndGetSingleGene(string mrnaSequence)
        {
            ResetCodonsList();
            return GetSingleGene(mrnaSequence);
        }

        public int GetNumberOfCharactersProcessed()
        {
            return _amountOfCharactersProcessed;
        }

        private SingleGene GetSingleGene(string mrnaSequence)
        {
            List<char> strAux = new List<char>();
            InitializeVariablesBeforeParsing();

            foreach (char newMrnaCharacter in mrnaSequence)
            {
                _amountOfCharactersProcessed++;

                if (IsItValidMrnaCharacter(newMrnaCharacter))
                {
                    strAux.Add(newMrnaCharacter);

                    if (DoWeHaveAlreadyOneCodon(strAux))
                    {
                        var singleCodon = GetCodon(strAux);
                        AddNewCodon(singleCodon);
                        strAux.Clear();

                        if (StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(singleCodon))
                        {
                            _stopCodonFound = true;
                            break;
                        }
                    }
                }
            }

            return _singleGene;
        }

        private void ResetCodonsList()
        {
            _singleGene._multipleCodons.Clear();
        }

        public bool GetStopCodonFound()
        {
            return _stopCodonFound;
        }

        private void InitializeVariablesBeforeParsing()
        {
            _stopCodonFound = false;
            _amountOfCharactersProcessed = 0;
        }


        private bool IsItValidMrnaCharacter(char newMrnaCharacter)
        {
            return _validCharacterDetectorHandler.IsItValidMrnaCharacter(newMrnaCharacter);
        }

        private bool DoWeHaveAlreadyOneCodon(List<char> strAux)
        {
            return strAux.Count == C_CODON_SIZE;
        }

        private string GetCodon(List<char> strAux)
        {
            return new string(strAux.ToArray());
        }

        private void AddNewCodon(string singleCodon)
        {
            _singleGene._multipleCodons.Add(singleCodon);
        }
    }
}
