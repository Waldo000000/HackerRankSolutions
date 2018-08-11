using System.Collections.Generic;
using System.Linq;

namespace Solutions.Algorithms.Strings
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/gem-stones/problem
    /// </summary>
    public class Gemstones
    {
        public static int CountGemstones(string[] compositions)
        {
            HashSet<char> minerals = new HashSet<char>(compositions.SelectMany(c => c.ToCharArray()));

            IList<HashSet<char>> compositionSets = compositions
                .Select(composition => new HashSet<char>(composition.ToCharArray()))
                .ToList();

            return minerals.Count(m => compositionSets.All(c => c.Contains(m)));
        }
    }
}