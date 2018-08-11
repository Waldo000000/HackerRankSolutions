using NUnit.Framework;
using Solutions.DataStructures.Advanced;

namespace Solutions.Tests.DataStructures.Advanced
{
    [TestFixture]
    public class JimAndTheSkyscrapersTest
    {
        [TestCase(new[] {3, 2, 1, 2, 3, 3}, ExpectedResult = 8)]
        [TestCase(new[] {1, 1000, 1}, ExpectedResult = 0)]
        public int Solve_ForAListOfHeights_ReturnsNumberOfPossibleDirectRoutes(int[] heights)
        {
            return JimAndTheSkyscrapers.Solve(heights);
        }
    }
}