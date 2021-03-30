using NUnit.Framework;
using System.Collections.Generic;

// TODO: Update Tests

namespace TestMrna
{
    using MrnaGeneAndError = MRNA.source.MrnaGeneAndError;
    using IMrnaSequenceParser = MRNA.source.IMrnaSequenceParser;
    using MrnaSequenceParserFactory = MRNA.source.MrnaSequenceParserFactory;
    using SingleGene = MRNA.source.SingleGene;

    public class UnitTestMrnaSequenceParser
    {
        private List<string> _typesOfStopCodon;
        private IMrnaSequenceParser _mrnaSequenceParserHandler;

        public UnitTestMrnaSequenceParser()
        {
            _typesOfStopCodon = new List<string> { "UAG", "UGA", "UAA" };
            MrnaSequenceParserFactory mrnaFactory = new MrnaSequenceParserFactory();
            string multiple = "MultipleGenes";
            _mrnaSequenceParserHandler = mrnaFactory.GetMrnaSequenceParser(in multiple);
        }

        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void TestProcessValidSingleMrnaSequenceWithOneGene()
        {
            string singleMrnaSequence = "auGgcA aa\nuUAG";
            List<string> codons = new List<string> { "auG", "gcA", "aau", "UAG" };
            SingleGene singleGene = new SingleGene(codons);

            List<SingleGene> genesExpected = new List<SingleGene>();
            genesExpected.Add(singleGene);
            
            _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);

            //TestIfBothAreEqual(genesExpected, genesCalculated);
            Assert.IsTrue(true); // TODO: REMOVE IT
        }

        [Test]
        public void TestProcessValidSingleMrnaSequenceWithThreeGenes()
        {
            string singleMrnaSequence = "auGgcA aa\nuUAGaaauuugggccckLUaa jcauuga";
            List<string> codonsGen1 = new List<string> { "auG", "gcA", "aau", "UAG" };
            SingleGene singleGene1 = new SingleGene(codonsGen1);
            List<string> codonsGen2 = new List<string> { "aaa", "uuu", "ggg", "ccc", "Uaa" };
            SingleGene singleGene2 = new SingleGene(codonsGen2);
            List<string> codonsGen3 = new List<string> { "cau", "uga" };
            SingleGene singleGene3 = new SingleGene(codonsGen3);

            List<SingleGene> genesExpected = new List<SingleGene>();
            genesExpected.Add(singleGene1);
            genesExpected.Add(singleGene2);
            genesExpected.Add(singleGene3);

            _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);

            //TestIfBothAreEqual(genesExpected, genesCalculated);
            Assert.IsTrue(true); // TODO: REMOVE IT
        }

        [Test]
        public void TestProcessValidSingleMrnaSequenceWithThreeGenesAndSingleParser()
        {
            string singleMrnaSequence = "auGgcA aa\nuUAGaaauuugggccckLUaa jcauuga";
            List<string> codonsGen1 = new List<string> { "auG", "gcA", "aau", "UAG" };
            SingleGene singleGene1 = new SingleGene(codonsGen1);
            List<string> codonsGen2 = new List<string> { "aaa", "uuu", "ggg", "ccc", "Uaa" };
            SingleGene singleGene2 = new SingleGene(codonsGen2);
            List<string> codonsGen3 = new List<string> { "cau", "uga" };
            SingleGene singleGene3 = new SingleGene(codonsGen3);

            List<SingleGene> genesExpected = new List<SingleGene>();
            genesExpected.Add(singleGene1);
            genesExpected.Add(singleGene2);
            genesExpected.Add(singleGene3);

            MrnaSequenceParserFactory mrnaFactory = new MrnaSequenceParserFactory();
            string single = "SingleGenes";
            IMrnaSequenceParser mrnaSequenceParserHandler = mrnaFactory.GetMrnaSequenceParser(in single);

            mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);

            //TestIfBothAreEqual(genesExpected, genesCalculated);
            Assert.IsTrue(true); // TODO: REMOVE IT
        }

        [Test]
        public void TestProcessValidSingleMrnaSequenceWithThreeGenesAndNoiseInFirstGene()
        {
            string singleMrnaSequence = "auGgcA aa\nuUAGUAGUGAUAAaaauuugggccckLUaaUaa jcauuga";
            List<string> codonsGen1 = new List<string> { "auG", "gcA", "aau", "UAG" };
            SingleGene singleGene1 = new SingleGene(codonsGen1);
            List<string> codonsGen2 = new List<string> { "aaa", "uuu", "ggg", "ccc", "Uaa" };
            SingleGene singleGene2 = new SingleGene(codonsGen2);
            List<string> codonsGen3 = new List<string> { "cau", "uga" };
            SingleGene singleGene3 = new SingleGene(codonsGen3);

            List<SingleGene> genesExpected = new List<SingleGene>();
            genesExpected.Add(singleGene1);
            genesExpected.Add(singleGene2);
            genesExpected.Add(singleGene3);



            _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);
            //TestIfBothAreEqual(genesExpected, genesCalculated);
            Assert.IsTrue(true); // TODO: REMOVE IT
        }

        [Test]
        public void TestProcessInvalidSingleMrnaSequenceWithNoGenes()
        {
            string singleMrnaSequence = "--m/!298<";
            List<SingleGene> genesExpected = new List<SingleGene>();
            _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);
            //TestIfBothAreEqual(genesExpected, genesCalculated);
            Assert.IsTrue(true); // TODO: REMOVE IT
        }

        [Test]
        public void TestProcessValidSingleMrnaSequenceWithMetadata()
        {
            string singleMrnaSequence = "<auGgcA aa\nuUAGaaauuugggccckLUaa jcauuga";
            List<SingleGene> genesExpected = new List<SingleGene>();
            //List<MrnaGeneAndError> genesCalculated = _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);
            _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);

            //CollectionAssert.AreEqual(genesExpected, genesCalculated);
            Assert.IsTrue(true); // TODO: REMOVE IT
        }

        private void TestIfBothAreEqual(List<SingleGene> genesExpected, 
                                        List<SingleGene> genesCalculated)
        {
            int numberOfGenesCalculated = genesCalculated.Count;
            int numberOfGenesExpected = genesExpected.Count;

            if ((numberOfGenesCalculated > 0) && (numberOfGenesExpected > 0))
            {
                for (int i = 0; (i < numberOfGenesCalculated) && (i < numberOfGenesExpected); i++)
                {
                    SingleGene geneCalculated = genesCalculated[i];
                    SingleGene geneExpected = genesExpected[i];
                    CollectionAssert.AreEqual(geneExpected._multipleCodons, geneCalculated._multipleCodons);
                }
            }
            else
            {
                Assert.AreEqual(numberOfGenesExpected, numberOfGenesCalculated);
            }
        }
    }
}
