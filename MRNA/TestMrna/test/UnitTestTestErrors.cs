using NUnit.Framework;
using System.Collections.Generic;

namespace TestMrna
{
    using ErrorManager = MRNA.source.ErrorManager;
    using ErrorTypes = MRNA.source.TypeOfErrors.ErrorTypes;
    using MrnaSequenceParser = MRNA.source.MrnaSequenceParser;


    public class UnitTestTestErrors
    {
        private MrnaSequenceParser _mrnaSequenceParserHandler;

        public UnitTestTestErrors()
        {
            _mrnaSequenceParserHandler = new MrnaSequenceParser();
        }

        [SetUp]
        public void Setup()
        {
        }

        private void ProcessSequenceAndCheckIfBothDictionariesAreTheSame(string mrnaSequence, 
                                                                         in Dictionary<ErrorTypes, bool> expectedResult)
        {
            _mrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
            ErrorManager errorManager = _mrnaSequenceParserHandler.GetErrorManager();
            List<ErrorTypes> errorTypes = new List<ErrorTypes>();
            errorTypes.Add(ErrorTypes.InvalidInput);
            errorTypes.Add(ErrorTypes.InvalidStringLength);
            errorTypes.Add(ErrorTypes.NoStopCodon);
            errorTypes.Add(ErrorTypes.NoError);

            foreach (ErrorTypes oneErrorType in errorTypes)
            {
                bool calculatedValue = errorManager.GetErrorValueOf(oneErrorType);
                bool expectedValue = expectedResult[oneErrorType];
                Assert.AreEqual(expectedValue, calculatedValue);
            }
        }

        [Test]
        public void TestNoError()
        {
            string mrnaSequence = "auGgcA aa\nuUAGaaauuugggccckLUaa jcauuga";
            Dictionary<ErrorTypes, bool> expectedResult = new Dictionary<ErrorTypes, bool>();
            expectedResult.Add(ErrorTypes.InvalidInput, false);
            expectedResult.Add(ErrorTypes.InvalidStringLength, false);
            expectedResult.Add(ErrorTypes.NoStopCodon, false);
            expectedResult.Add(ErrorTypes.NoError, true);
            
            ProcessSequenceAndCheckIfBothDictionariesAreTheSame(mrnaSequence, in expectedResult);            
        }

        [Test]
        public void TestInvalidInput()
        {
            string mrnaSequence = "--m/!298<";

            Dictionary<ErrorTypes, bool> expectedResult = new Dictionary<ErrorTypes, bool>();
            expectedResult.Add(ErrorTypes.InvalidInput, true);
            expectedResult.Add(ErrorTypes.InvalidStringLength, true);
            expectedResult.Add(ErrorTypes.NoStopCodon, true);
            expectedResult.Add(ErrorTypes.NoError, false);

            ProcessSequenceAndCheckIfBothDictionariesAreTheSame(mrnaSequence, in expectedResult);
        }

        [Test]
        public void TestInvalidStringLength()
        {
            string mrnaSequence = "auGgcA aa\nucUAGa";

            Dictionary<ErrorTypes, bool> expectedResult = new Dictionary<ErrorTypes, bool>();
            expectedResult.Add(ErrorTypes.InvalidInput, false);
            expectedResult.Add(ErrorTypes.InvalidStringLength, true);
            expectedResult.Add(ErrorTypes.NoStopCodon, true);
            expectedResult.Add(ErrorTypes.NoError, false);

            ProcessSequenceAndCheckIfBothDictionariesAreTheSame(mrnaSequence, in expectedResult);
        }

        [Test]
        public void TestOneGeneWithNoStopCodon()
        {
            string mrnaSequence = "auGgcA aa\nucUA";

            Dictionary<ErrorTypes, bool> expectedResult = new Dictionary<ErrorTypes, bool>();
            expectedResult.Add(ErrorTypes.InvalidInput, false);
            expectedResult.Add(ErrorTypes.InvalidStringLength, false);
            expectedResult.Add(ErrorTypes.NoStopCodon, true);
            expectedResult.Add(ErrorTypes.NoError, false);

            ProcessSequenceAndCheckIfBothDictionariesAreTheSame(mrnaSequence, in expectedResult);
        }
    }
}
