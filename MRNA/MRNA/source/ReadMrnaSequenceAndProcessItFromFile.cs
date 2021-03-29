using System;


namespace MRNA.source
{
    class ReadMrnaSequenceAndProcessItFromFile : ReadMrnaSequenceAndProcessItBase, IReadMrnaSequenceAndProcessIt
    {
        public ReadMrnaSequenceAndProcessItFromFile()
        {

        }

        public void ReadMrnaSequenceAndProcessIt(in string[] args)
        {
            int counter = 0;
            string line;
            string pathToFile = @"C:\Users\sferrand\Sergio\00_ACTUAL\CSharpProjects\AdcChallenges\MRNA_Sequence_Processor\MRNA\data\refMrna.fa.modif.txt";
            //string pathToFile = GetFileNameAndPath(in args);
            SetMrnaSequenceParser(in args);

            System.IO.StreamReader file =
                new System.IO.StreamReader(pathToFile);
            while ((line = file.ReadLine()) != null)
            {
                ProcessMrnaSequence(in line);

                counter++;
            }

            file.Close();
        }

        private string GetFileNameAndPath(in string [] args)
        {
            string fileNameAndPath = "";

            return fileNameAndPath;
        }
    }
}
