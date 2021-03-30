

namespace MRNA.source
{
    class ReadMrnaSequenceAndProcessItBase
    {
        private IMrnaSequenceParser _iMrnaSequenceParserHandler;
        private const int C_TYPE_OF_SEQUENCER_ARGUMENT_POSITION = 1;

        protected ReadMrnaSequenceAndProcessItBase()
        {

        }

        protected void SetMrnaSequenceParser(in string[] args)
        {
            MrnaSequenceParserFactory mrnaFactory = new MrnaSequenceParserFactory();
            _iMrnaSequenceParserHandler = mrnaFactory.GetMrnaSequenceParser(
                                                GetTypeOfSequencer(in args));
        }

        protected void ProcessMrnaSequence(in string mrnaSequence)
        {
            _iMrnaSequenceParserHandler.ProcessMrnaSequence(mrnaSequence);
        }

        private string GetTypeOfSequencer(in string[] args)
        {
            string typeOfSequencer = "";

            if (args.Length >= C_TYPE_OF_SEQUENCER_ARGUMENT_POSITION)
            {
                typeOfSequencer = args[C_TYPE_OF_SEQUENCER_ARGUMENT_POSITION];
            }

            return typeOfSequencer;
        }
    }
}
