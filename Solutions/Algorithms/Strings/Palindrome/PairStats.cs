using System;
using Pair = System.Tuple<char, char>;

namespace Solutions.Algorithms.Strings.Palindrome
{
    internal class PairStats
    {
        public readonly Pair Pair;

        /// <summary>
        /// Number of other pairs that mismatch, counted from highest place to place just above pivot
        /// </summary>
        public readonly int NumMismatchesAtLowerPlaces;

        public PairStats(Pair pair, int numMismatchesAtLowerPlaces)
        {
            Pair = pair;
            NumMismatchesAtLowerPlaces = numMismatchesAtLowerPlaces;
        }
    }
}