using System.Text.RegularExpressions;

namespace Solutions.Algorithms.Strings
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/camelcase/problem
    /// </summary>
    public class CamelCase
    {
        public static int Camelcase(string s)
        {
            return Regex.Matches(s, "(^[A-Za-z]|[A-Z])[a-z]*").Count;
        }
    }
}