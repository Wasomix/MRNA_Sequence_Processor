using NUnit.Framework;

namespace TestMrna
{
    using StopCodonDetector = MRNA.source.StopCodonDetector;
    public class TestsStopCodon
    {
        [SetUp]
        public void Setup()
        {
            StopCodonDetector.ResetStopCodonCounter();
        }

        [Test]
        public void TestStopCodonUAGDetected()
        {
            string stopCodon = "UAG";
            bool expectedResult = true;
            bool calculatedResult = StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            Assert.AreEqual(expectedResult, calculatedResult);
        }

        [Test]
        public void TestStopCodonUGADetected()
        {
            string stopCodon = "UGA";
            bool expectedResult = true;
            bool calculatedResult = StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            Assert.AreEqual(expectedResult, calculatedResult);
        }

        [Test]
        public void TestStopCodonUAADetected()
        {
            string stopCodon = "UAA";
            bool expectedResult = true;
            bool calculatedResult = StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            Assert.AreEqual(expectedResult, calculatedResult);
        }

        [Test]
        public void TestWrongStopCodon()
        {
            string stopCodon = "UUA";
            bool expectedResult = false;
            bool calculatedResult = StopCodonDetector.CheckIfItIsStopCodonAndUpdateStopCodonCounter(stopCodon);
            Assert.AreEqual(expectedResult, calculatedResult);
        }
    }
 }
