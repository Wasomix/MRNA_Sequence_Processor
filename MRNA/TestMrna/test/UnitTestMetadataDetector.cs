using NUnit.Framework;

namespace TestMrna
{
    using MetadataDetector = MRNA.source.MetadataDetector;

    public class UnitTestMetadataDetector
    {
        MetadataDetector _metadataDetectorHandler;

        [SetUp]
        public void Setup()
        {
            AllocateMetadataDetectorMemoryIfNecessary();
        }

        private void AllocateMetadataDetectorMemoryIfNecessary()
        {
            if (_metadataDetectorHandler == null)
            {
                _metadataDetectorHandler = new MetadataDetector();
            }
        }

        [Test]
        public void TestMetadata()
        {
            string mrnaSequence = "<AUC GaCcG";
            bool isNotMetadataExpectedResult = false;
            bool isNotMetadataCalcutedResult = _metadataDetectorHandler.IsNotMetadata(mrnaSequence);

            Assert.AreEqual(isNotMetadataExpectedResult, isNotMetadataCalcutedResult);
        }

        [Test]
        public void TestNoMetadata()
        {
            string mrnaSequence = ">-.!AUC GaCcG";
            bool isNotMetadataExpectedResult = true;
            bool isNotMetadataCalcutedResult = _metadataDetectorHandler.IsNotMetadata(mrnaSequence);

            Assert.AreEqual(isNotMetadataExpectedResult, isNotMetadataCalcutedResult);
        }

        [Test]
        public void TestNoMetadataWithCommentCharacter()
        {
            string mrnaSequence = "-.!AUC< GaCcG";
            bool isNotMetadataExpectedResult = true;
            bool isNotMetadataCalcutedResult = _metadataDetectorHandler.IsNotMetadata(mrnaSequence);

            Assert.AreEqual(isNotMetadataExpectedResult, isNotMetadataCalcutedResult);
        }
    }
}
