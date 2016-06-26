﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Builder
    {
        public IEnumerable<int> BuildIntegerSequence()
        {
            //var integer = Enumerable.Range(0, 10)
            //                        .Select(i => 5 + (10 * i));

            var integer = Enumerable.Repeat(-1, 10);
            return integer;
        }

        public IEnumerable<string> BuildStringSequence()
        {
            var rand = new Random();
            //var strings = Enumerable.Range(0, 10)
            //                        .Select(i => ((char)('A' + rand.Next(0, 26))).ToString());

            var strings = Enumerable.Repeat("A", 10);

            return strings;
        }

        public IEnumerable<int> CompareSequences()
        {
            var seq1 = Enumerable.Range(0, 10);
            var seq2 = Enumerable.Range(0, 10)
                .Select(i => i * i);

            return seq1.Union(seq2);
        }
    }
}
