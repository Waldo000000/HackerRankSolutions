using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Algorithms.Strings
{
    public class CharPair : Tuple<char, char>
    {
        public CharPair(char item1, char item2) : base(item1, item2)
        {
        }

        public static CharPair Create(char item1, char item2)
        {
            return new CharPair(item1, item2);
        }

        public bool Matches()
        {
            return Item1 == Item2;
        }
    }

    /// <summary>
    /// https://www.hackerrank.com/challenges/richie-rich/problem
    /// </summary>
    public class HighestValuePalindrome
    {
        public static string GetHighestValuePalindrome(string input, int maxAllowedChanges)
        {
            List<CharPair> zipped = input.Zip(input.Reverse(), CharPair.Create).ToList();

            // Only need to check up to the pivot
            int totalPairsToCheck = (zipped.Count - 1) / 2 + 1;

            // Maximise highest-value places first
            // Always keep enough budget spare to fix remaining mismatching pairs, if possible
            var budgetRemaining = maxAllowedChanges;
            for (int i = 0; i < totalPairsToCheck; i++)
            {
                List<CharPair> pairsYetToCheck = zipped.GetRange(i + 1, totalPairsToCheck - (i + 1));
                int mismatchingPairsYetToCheck = pairsYetToCheck.Count(pair => !pair.Matches());
                int pivotDiscount = zipped.Count % 2 == 1 && i == (zipped.Count - 1) / 2
                    ? 1
                    : 0;
                int budgetForThisPair = budgetRemaining - mismatchingPairsYetToCheck + pivotDiscount;
                if (budgetForThisPair >= 1)
                {
                    int cost = budgetForThisPair >= 2
                        ? SetBothToMax(zipped, i)
                        : SetToHigher(zipped, i);
                    budgetRemaining -= cost + pivotDiscount;
                }
                else if (!zipped[i].Matches())
                {
                    // We've run out of budget to fix this mismatching pair
                    return "-1";
                }
            }

            return new string(zipped.Select(pair => pair.Item1).ToArray());
        }

        private static int SetToHigher(List<CharPair> zipped, int i)
        {
            CharPair pair = zipped[i];
            int targetDigit = new[] {pair.Item1, pair.Item2}.Select(c => int.Parse(c.ToString())).Max();
            char targetChar = (char) (targetDigit + '0');
            return SetBothToChar(zipped, i, targetChar);
        }

        private static int SetBothToMax(List<CharPair> zipped, int i)
        {
            return SetBothToChar(zipped, i, '9');
        }

        private static int SetBothToChar(List<CharPair> zipped, int i, char targetChar)
        {
            CharPair pair = zipped[i];
            var costToChange = new[] {pair.Item1, pair.Item2}.Count(c => c != targetChar);
            zipped[i] = new CharPair(targetChar, targetChar);
            zipped[zipped.Count - 1 - i] = new CharPair(targetChar, targetChar);
            return costToChange;
        }
    }
}