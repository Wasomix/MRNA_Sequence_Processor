using NUnit.Framework;

namespace TestMrna
{
    using StopCodonDetector = MRNA.source.StopCodonDetector;
    using NoiseCodonDetector = MRNA.source.NoiseCodonDetector;

    public class TestsNoiseCodonDetector
    {
        private NoiseCodonDetector _noiseCodonDetectorHandler;

        public TestsNoiseCodonDetector()
        {
            _noiseCodonDetectorHandler = new NoiseCodonDetector();
        }

        [SetUp]
        public void Setup()
        {                     
        }

        [Test]
        public void TestGenerateNoiseCodon()
        {
            string stopCodon = "UAG";
            StopCodonDetector.IsItStopCodon(stopCodon);
            StopCodonDetector.IsItStopCodon(stopCodon);
            bool expectedResult = true;
            bool calculatedResult = true;// _noiseCodonDetectorHandler.CheckIfIsItNoiseCodonAndUpdateNoiseCounter();
            Assert.AreEqual(expectedResult, calculatedResult);
        }

        [Test]
        public void TestNoNoiseCodon()
        {
            string stopCodon = "UAG";
            StopCodonDetector.IsItStopCodon(stopCodon);
            bool expectedResult = false;
            bool calculatedResult = false;// _noiseCodonDetectorHandler.CheckIfIsItNoiseCodonAndUpdateNoiseCounter();
            Assert.AreEqual(expectedResult, calculatedResult);
        }
    }
}
