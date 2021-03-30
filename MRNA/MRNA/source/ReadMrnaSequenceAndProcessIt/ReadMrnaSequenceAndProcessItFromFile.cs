using System;
using System.IO;

namespace MRNA.source
{
    class ReadMrnaSequenceAndProcessItFromFile : ReadMrnaSequenceAndProcessItBase, IReadMrnaSequenceAndProcessIt
    {
        private const int C_ARGUMENT_POSITION_FOR_PATH_TO_FILE = 3;

        public ReadMrnaSequenceAndProcessItFromFile()
        {

        }

        public void ReadMrnaSequenceAndProcessIt(in string[] args)
        {
            string pathToFile = GetFileNameAndPath(in args);
            SetMrnaSequenceParser(in args);

            if(File.Exists(pathToFile))
            {
                ReadMrnaSequenceFromFileAndProcessIt(in pathToFile);
            } else
            {
                Console.WriteLine("Please enter a correct file name and path");
            }
        }

        private string GetFileNameAndPath(in string [] args)
        {
            string fileNameAndPath = "";

            if (args.Length == C_ARGUMENT_POSITION_FOR_PATH_TO_FILE)
            {
                fileNameAndPath = args[C_ARGUMENT_POSITION_FOR_PATH_TO_FILE-1];
            }

            return fileNameAndPath;
        }

        private void ReadMrnaSequenceFromFileAndProcessIt(in string pathToFile)
        {
            string line;
            System.IO.StreamReader file =
            new System.IO.StreamReader(pathToFile);
            while ((line = file.ReadLine()) != null)
            {
                ProcessMrnaSequence(in line);
            }

            file.Close();
        }
    }
}
