// This class is responsible for storing single genes. A single gene is going
// to be composed for one or more codons.

using System.Collections.Generic;


namespace MRNA.source
{
    public class SingleGene
    {
        public List<string> _multipleCodons { get; set; }

        public SingleGene()
        {
            _multipleCodons = new List<string>();
        }

        public SingleGene(List<string> list)
        {
            _multipleCodons = list;
        }
    }
}
