using System.Collections.Generic;
using NUnit.Framework;
using Solutions.Algorithms.Strings;

namespace Solutions.Tests.Algorithms.Strings
{
    [TestFixture]
    public class GemstonesTest
    {
        [TestCase("abcdde","baccd","eeabg", ExpectedResult = 2)]
        [TestCase("a", "a", ExpectedResult = 1)]
        [TestCase("ab", "a", ExpectedResult = 1)]
        [TestCase("ab", "ab", ExpectedResult = 2)]
        [TestCase("fjdkl","fdjoii", "fdksj", "afjsid", ExpectedResult = 3)]
        public int Gemstones_SomeMineralLists_CountsNumMineralsThatAppearInAllRocks(params string [] compositions)
        {
            return Gemstones.CountGemstones(compositions);
        }
    }
}