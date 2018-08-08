using NUnit.Framework;
using Solutions.Algorithms.Strings;

namespace Solutions.Tests.Algorithms.Strings
{
    [TestFixture]
    public class CamelCaseTest
    {
        [TestCase("a", ExpectedResult = 1)]
        [TestCase("foo", ExpectedResult = 1)]
        [TestCase("fooBar", ExpectedResult = 2)]
        [TestCase("saveChangesInTheEditor", ExpectedResult = 5)]
        public int CamelCase_SomeString_CountsWords(string input)
        {
            return CamelCase.Camelcase(input);
        }
    }
}