using NUnit.Framework;
using System.Collections.Generic;

namespace TestMrna
{
    using MrnaSequenceParser = MRNA.source.MrnaSequenceParser;
    using SingleGene = MRNA.source.SingleGene;

    public class UnitTestMrnaSequenceParser
    {
        private List<string> _typesOfStopCodon;
        private MrnaSequenceParser _mrnaSequenceParserHandler;

        public UnitTestMrnaSequenceParser()
        {
            _typesOfStopCodon = new List<string> { "UAG", "UGA", "UAA" };
            _mrnaSequenceParserHandler = new MrnaSequenceParser();
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
            
            List<SingleGene> genesCalculated = _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);
            TestIfBothAreEqual(genesExpected, genesCalculated);
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

            List<SingleGene> genesCalculated = _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);
            TestIfBothAreEqual(genesExpected, genesCalculated);
        }
        
        [Test]
        public void TestProcessInvalidSingleMrnaSequenceWithNoGenes()
        {
            string singleMrnaSequence = "--m/!298<";
            List<SingleGene> genesExpected = new List<SingleGene>();
            List<SingleGene> genesCalculated = _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);
            TestIfBothAreEqual(genesExpected, genesCalculated);
        }

        [Test]
        public void TestProcessValidSingleMrnaSequenceWithMetadata()
        {
            string singleMrnaSequence = "<auGgcA aa\nuUAGaaauuugggccckLUaa jcauuga";
            List<SingleGene> genesExpected = new List<SingleGene>();
            List<SingleGene> genesCalculated = _mrnaSequenceParserHandler.ProcessMrnaSequence(singleMrnaSequence);

            CollectionAssert.AreEqual(genesExpected, genesCalculated);
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
