using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    class TimeInWordsTest
    {
        [TestCase(5, 0, ExpectedResult = "five o'clock")]
        public string OnTheHour_ReturnsOclock(int hours, int minutes)
        {
            return TimeInWords.ConvertTimeToWords(hours, minutes);
        }
    }
}