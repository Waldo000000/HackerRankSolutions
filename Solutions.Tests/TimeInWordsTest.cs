using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    class TimeInWordsTest
    {
        [Test]
        public void OnTheHour_ReturnsOclock()
        {
            Assert.That(TimeInWords.ConvertTimeToWords(5, 0), Is.EqualTo("five o'clock"));
        }
    
    }
}