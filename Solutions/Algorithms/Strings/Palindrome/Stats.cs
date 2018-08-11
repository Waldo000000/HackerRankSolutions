using System.Collections.Generic;

namespace Solutions.Algorithms.Strings.Palindrome
{
    internal class Stats
    {
        /// <summary>
        /// List of stats about each digit pair, ordered from highest place to place just above pivot
        /// </summary>
        public IList<PairStats> Pairs { get; }

        /// <summary>
        /// Pivot digit, or empty if list was of even length
        /// </summary>
        public IList<char> Pivot { get; }

        /// <summary>
        /// Number of digit changes to make a palindrome
        /// </summary>
        public int MinRequiredChanges { get; }

        public Stats(IList<PairStats> pairs, IList<char> pivot, int minRequiredChanges)
        {
            Pairs = pairs;
            Pivot = pivot;
            MinRequiredChanges = minRequiredChanges;
        }
    }
}