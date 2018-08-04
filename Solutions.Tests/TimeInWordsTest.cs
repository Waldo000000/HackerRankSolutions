using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    class TimeInWordsTest
    {
        [TestCase(5, 0, ExpectedResult = "five o'clock")]
        [TestCase(12, 0, ExpectedResult = "twelve o'clock")]
        public string OnTheHour_ReturnsOclock(int hours, int minutes)
        {
            return TimeInWords.ConvertTimeToWords(hours, minutes);
        }

        [TestCase(5, 1, ExpectedResult = "one minute past five")]
        [TestCase(5, 10, ExpectedResult = "ten minutes past five")]
        public string LessThanThirtyMinutes_MinutesPastTheHour(int hours, int minutes)
        {
            return TimeInWords.ConvertTimeToWords(hours, minutes);
        }

        [TestCase(5, 15, ExpectedResult = "quarter past five")]
        public string FifteenMinutes_QuarterPast(int hours, int minutes)
        {
            return TimeInWords.ConvertTimeToWords(hours, minutes);
        }
    }
}