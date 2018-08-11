using System.Collections.Generic;

namespace Solutions.Algorithms.Strings.Palindrome
{
    internal class Result
    {
        public IList<Pair> Pairs { get; }

        /// <summary>
        /// Empty if the list was even
        /// </summary>
        public IList<char> Pivot { get; }

        public Result(IList<Pair> pairs, IList<char> pivot)
        {
            Pairs = pairs;
            Pivot = pivot;
        }
    }
}