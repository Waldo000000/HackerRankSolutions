namespace Solutions
{
    public class TimeInWords
    {
        private static readonly string[] Units =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        };

        /// <summary>
        /// Given the time in numerals, convert it into words
        /// https://www.hackerrank.com/challenges/the-time-in-words/problem
        /// </summary>
        public static string ConvertTimeToWords(int hour, int minute)
        {
            string hourAmount = Units[hour];
            if (minute == 0)
            {
                return $"{hourAmount} o'clock";
            }

            if (minute == 15)
            {
                return $"quarter past {hourAmount}";
            }

            string minuteStringSuffix = GetMinuteStringSuffix(minute);
            return $"{Units[minute]} {minuteStringSuffix} past {hourAmount}";
        }

        private static string GetMinuteStringSuffix(int minute)
        {
            return minute == 1
                ? "minute"
                : "minutes";
        }
    }
}