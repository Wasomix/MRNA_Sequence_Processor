using NUnit.Framework;

namespace TestMrna
{
    using ErrorDetector = MRNA.source.ErrorDetector;
    using TypeOfErrors = MRNA.source.TypeOfErrors;
    using MrnaSequenceParser = MRNA.source.MrnaSequenceParser;


    public class UnitTestTestErrors
    {
        private MrnaSequenceParser _mrnaSequenceParserHandler;
        private ErrorDetector _errorDetectorHandler;

        public UnitTestTestErrors()
        {
            _mrnaSequenceParserHandler = new MrnaSequenceParser();
            _errorDetectorHandler = new ErrorDetector();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNoError()
        {
            string mrnaSequence = "auGgcA aa\nuUAGaaauuugggccckLUaa jcauuga";
            TypeOfErrors.ErrorTypes stopCodonFoundExpected = TypeOfErrors.ErrorTypes.NoError;
            _mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
            TypeOfErrors.ErrorTypes stopCodonFoundCalculated = _errorDetectorHandler.GetTypeOfError();
            Assert.AreEqual(stopCodonFoundExpected, stopCodonFoundCalculated);
        }

        [Test]
        public void TestInvalidInput()
        {
            string mrnaSequence = "--m/!298<";
            TypeOfErrors.ErrorTypes stopCodonFoundExpected = TypeOfErrors.ErrorTypes.InvalidInput;
            _mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
            TypeOfErrors.ErrorTypes stopCodonFoundCalculated = _errorDetectorHandler.GetTypeOfError();
            Assert.AreEqual(stopCodonFoundExpected, stopCodonFoundCalculated);
        }

        [Test]
        public void TestInvalidStringLength()
        {
            string mrnaSequence = "auGgcA aa\nucUAGaa";
            TypeOfErrors.ErrorTypes stopCodonFoundExpected = TypeOfErrors.ErrorTypes.InvalidStringLength;
            _mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
            TypeOfErrors.ErrorTypes stopCodonFoundCalculated = _errorDetectorHandler.GetTypeOfError();
            Assert.AreEqual(stopCodonFoundExpected, stopCodonFoundCalculated);
        }

        [Test]
        public void TestOneGeneWithNoStopCodon()
        {
            string mrnaSequence = "auGgcA aa\nucUA";
            TypeOfErrors.ErrorTypes stopCodonFoundExpected = TypeOfErrors.ErrorTypes.NoStopCodon;
            _mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
            TypeOfErrors.ErrorTypes stopCodonFoundCalculated = _errorDetectorHandler.GetTypeOfError();
            Assert.AreEqual(stopCodonFoundExpected, stopCodonFoundCalculated);
        }
    }
}
