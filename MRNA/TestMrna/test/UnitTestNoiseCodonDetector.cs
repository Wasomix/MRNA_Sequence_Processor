using NUnit.Framework;

namespace TestMrna
{
    using StopCodonDetector = MRNA.source.StopCodonDetector;
    using NoiseCodonDetector = MRNA.source.NoiseCodonDetector;

    public class TestsNoiseCodonDetector
    {
        private NoiseCodonDetector _noiseCodonDetectorHandler;

        [SetUp]
        public void Setup()
        {
            AllocateNoiseDetectorMemoryIfNecessary();            
            StopCodonDetector.ResetStopCodonCounter();
        }

        private void AllocateNoiseDetectorMemoryIfNecessary()
        {
            if(_noiseCodonDetectorHandler==null)
            {
                _noiseCodonDetectorHandler = new NoiseCodonDetector();
            }            
        }

        [Test]
        public void TestGenerateNoiseCodon()
        {
            string stopCodon = "UAG";
            StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            bool expectedResult = true;
            bool calculatedResult = _noiseCodonDetectorHandler.CheckIfIsItNoiseCodonAndUpdateNoiseCounter();
            Assert.AreEqual(expectedResult, calculatedResult);
        }

        [Test]
        public void TestNoNoiseCodon()
        {
            string stopCodon = "UAG";
            StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            bool expectedResult = false;
            bool calculatedResult = _noiseCodonDetectorHandler.CheckIfIsItNoiseCodonAndUpdateNoiseCounter();
            Assert.AreEqual(expectedResult, calculatedResult);
        }
    }
}
