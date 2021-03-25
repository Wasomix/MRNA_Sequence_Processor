// This class is responsible for detecting valid mRNA characters,
// i.e. A, U, G, C, a, u, g, c

using System.Collections.Generic;


namespace MRNA.source
{
    class ValidCharacterDetector
    {
        List<char> _validMrnaCharacters; 

        public ValidCharacterDetector()
        {
            _validMrnaCharacters = new List<char> { 'A', 'U', 'G', 'C', 'a', 'u', 'g', 'c' };
        }

        public bool IsItValidMrnaCharacter(char mrnaCharacter)
        {
            return _validMrnaCharacters.Contains(mrnaCharacter);
        }
    }
}
