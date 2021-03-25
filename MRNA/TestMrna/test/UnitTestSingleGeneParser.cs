using NUnit.Framework;
using System.Collections.Generic;

namespace TestMrna
{
    using SingleGene = MRNA.source.SingleGene;
    using SingleGeneParser = MRNA.source.SingleGeneParser;

    public class UnitTestSingleGeneParser
    {
        private SingleGeneParser _singleGeneParserHandler;

        public UnitTestSingleGeneParser()
        {
            _singleGeneParserHandler = new SingleGeneParser();
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestSingleGeneParserThreeCodonsAndValidNumberOfChars()
        {
            string mrnaSequence = "auGgcA aa\nuUAG";
            List<string> codons = new List<string> { "auG", "gcA", "aau", "UAG" };
            SingleGene singleGeneExpected = new SingleGene(codons);
            SingleGene singleGeneCalculated = _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            CollectionAssert.AreEqual(singleGeneExpected._multipleCodons, singleGeneCalculated._multipleCodons);
        }

        [Test]
        public void TestSingleGeneParserFourCodonsAndValidNumberOfChars()
        {
            string mrnaSequence = "aaauuuggg ccckLUaa";
            List<string> codons = new List<string> { "aaa", "uuu", "ggg", "ccc", "Uaa" };
            SingleGene singleGeneExpected = new SingleGene(codons);
            SingleGene singleGeneCalculated = _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            CollectionAssert.AreEqual(singleGeneExpected._multipleCodons, singleGeneCalculated._multipleCodons);
        }

        [Test]
        public void TestSingleGeneParserThreeCodonsAndInvalidNumberOfChars()
        {
            string mrnaSequence = "auGgcA aa\nucUAG";
            List<string> codons = new List<string> { "auG", "gcA", "aau", "cUA" };
            SingleGene singleGeneExpected = new SingleGene(codons);
            SingleGene singleGeneCalculated = _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            CollectionAssert.AreEqual(singleGeneExpected._multipleCodons, singleGeneCalculated._multipleCodons);
        }
                
        [Test]
        public void TestStopCodonFoundInStringWithStopCodon()
        {
            string mrnaSequence = "auGgcA aa\nuUAG";
            bool stopCodonFoundExpected = true;
            _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            bool stopCodonFoundCalculated = _singleGeneParserHandler.GetStopCodonFound();
            Assert.AreEqual(stopCodonFoundExpected, stopCodonFoundCalculated);
        }

        [Test]
        public void TestStopCodonFoundInStringWithNoStopCodon()
        {
            string mrnaSequence = "auGgcA aa\nucUA";
            bool stopCodonFoundExpected = false;
            _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            bool stopCodonFoundCalculated = _singleGeneParserHandler.GetStopCodonFound();
            Assert.AreEqual(stopCodonFoundExpected, stopCodonFoundCalculated);
        }

        [Test]
        public void TestAmountOfCharactersProcessedInStringWithStopCodon()
        {
            string mrnaSequence = "auGgcA aa\nucUAG";
            int numberOfCharactersExpected = mrnaSequence.Length;
            _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            int numberOfCharactersCalculated = _singleGeneParserHandler.GetNumberOfCharactersProcessed();
            Assert.AreEqual(numberOfCharactersExpected, numberOfCharactersCalculated);
        }

        [Test]
        public void TestAmountOfCharactersProcessedInStringWithNoStopCodon()
        {
            string mrnaSequence = "auGgcA aa\nucUA";
            int numberOfCharactersExpected = mrnaSequence.Length;
            _singleGeneParserHandler.ResetCodonsListAndGetSingleGene(mrnaSequence);
            int numberOfCharactersCalculated = _singleGeneParserHandler.GetNumberOfCharactersProcessed();
            Assert.AreEqual(numberOfCharactersExpected, numberOfCharactersCalculated);
        }
    }
}
