using NUnit.Framework;
using System.Collections.Generic;

namespace TestMrna
{
    using ValidCharacterDetector = MRNA.source.ValidCharacterDetector;

    public class TestsValidCharacter
    {
        private ValidCharacterDetector _validCharacterDetectorHandler;

        [SetUp]
        public void Setup()
        {
            AllocateValidCharacterDetectorMemoryIfNecessary();
        }

        private void AllocateValidCharacterDetectorMemoryIfNecessary()
        {
            if (_validCharacterDetectorHandler == null)
            {
                _validCharacterDetectorHandler = new ValidCharacterDetector();
            }
        }

        private bool AreAllValidMrnaCharacters(List<char> mrnaCharacter)
        {
            bool allAreValidMrnaCharacters = true;

            foreach (char newMrnaCharacter in mrnaCharacter)
            {
                if (IsItNotValidMrnaCharacter(newMrnaCharacter))
                {
                    allAreValidMrnaCharacters = false;
                    break;
                }
            }

            return allAreValidMrnaCharacters;
        }

        private bool IsItNotValidMrnaCharacter(char newMrnaCharacter)
        {
            return !_validCharacterDetectorHandler.IsItValidMrnaCharacter(newMrnaCharacter);
        }

        [Test]
        public void TestValidCharactersAllUpperCase()
        {
            List<char> mrnaCharacter = new List<char> { 'A', 'U', 'G', 'C' };
            bool areTheyValidCharactersExpectedResult = true;
            bool areTheyValidCharactersCalculatedResult = AreAllValidMrnaCharacters(mrnaCharacter);

            Assert.AreEqual(areTheyValidCharactersExpectedResult, 
                areTheyValidCharactersCalculatedResult);
        }

        [Test]
        public void TestValidCharactersAllLowerCase()
        {
            List<char> mrnaCharacter = new List<char> { 'a', 'u', 'g', 'c' };
            bool areTheyValidCharactersExpectedResult = true;
            bool areTheyValidCharactersCalculatedResult = AreAllValidMrnaCharacters(mrnaCharacter);

            Assert.AreEqual(areTheyValidCharactersExpectedResult,
                areTheyValidCharactersCalculatedResult);
        }

        [Test]
        public void TestValidCharactersMixUpperandLowerCase()
        {
            List<char> mrnaCharacter = new List<char> { 'A', 'a', 'U', 'u', 
                                                        'G', 'g', 'C', 'c' };
            bool areTheyValidCharactersExpectedResult = true;
            bool areTheyValidCharactersCalculatedResult = AreAllValidMrnaCharacters(mrnaCharacter);

            Assert.AreEqual(areTheyValidCharactersExpectedResult,
                areTheyValidCharactersCalculatedResult);
        }

        [Test]
        public void TestInvalidCharacterWhiteSpace()
        {
            List<char> mrnaCharacter = new List<char> { ' ', 'U', 'G', 'C' };
            bool areTheyValidCharactersExpectedResult = false;
            bool areTheyValidCharactersCalculatedResult = AreAllValidMrnaCharacters(mrnaCharacter);

            Assert.AreEqual(areTheyValidCharactersExpectedResult,
                areTheyValidCharactersCalculatedResult);
        }

        [Test]
        public void TestInvalidCharacterLowerCaseLetter()
        {
            List<char> mrnaCharacter = new List<char> { 'A', 'U', 'x', 'C' };
            bool areTheyValidCharactersExpectedResult = false;
            bool areTheyValidCharactersCalculatedResult = AreAllValidMrnaCharacters(mrnaCharacter);

            Assert.AreEqual(areTheyValidCharactersExpectedResult,
                areTheyValidCharactersCalculatedResult);
        }

        [Test]
        public void TestInvalidCharacterUpperCaseLetter()
        {
            List<char> mrnaCharacter = new List<char> { 'D', 'U', 'x', 'C' };
            bool areTheyValidCharactersExpectedResult = false;
            bool areTheyValidCharactersCalculatedResult = AreAllValidMrnaCharacters(mrnaCharacter);

            Assert.AreEqual(areTheyValidCharactersExpectedResult,
                areTheyValidCharactersCalculatedResult);
        }
    }
}