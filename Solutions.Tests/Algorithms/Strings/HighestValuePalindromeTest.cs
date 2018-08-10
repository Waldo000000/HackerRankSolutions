using NUnit.Framework;
using Solutions.Algorithms.Strings;

namespace Solutions.Tests.Algorithms.Strings
{
    [TestFixture]
    public class HighestValuePalindromeTest
    {
        [TestCase("3943", 1, ExpectedResult = "3993")]
        [TestCase("092282", 3, ExpectedResult = "992299")]
        [TestCase("0011", 1, ExpectedResult = "-1")]
        [TestCase("18171", 2, ExpectedResult = "19191")]
        [TestCase("12345", 2, ExpectedResult = "54345")]
        [TestCase("63939", 4, ExpectedResult = "99999")]
        [TestCase("98629932781", 5, ExpectedResult = "99729992799")]
        [TestCase("98629932781", 4, ExpectedResult = "98929992989")]
        [TestCase("98629932781", 3, ExpectedResult = "98729992789")]
        [TestCase("98629932781", 2, ExpectedResult = "-1")]
        [TestCase("98629932781", 1, ExpectedResult = "-1")]
        [TestCase("98629932781", 0, ExpectedResult = "-1")]
        [TestCase("5", 1, ExpectedResult = "9")]
        [TestCase("12321", 1, ExpectedResult = "12921")]
        public string GetHighestValuePalindrome_Always_ReturnsHighestValuePalindrome(
            string input,
            int maxAllowedChanges
        )
        {
            return HighestValuePalindrome.GetHighestValuePalindrome(input, maxAllowedChanges);
        }
    }
}
