using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Algorithms.Strings.Palindrome
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/richie-rich/problem
    /// </summary>
    public class HighestValuePalindrome
    {
        public static string GetHighestValuePalindrome(string input, int maxAllowedChanges)
        {
            Stats stats = GetStats(input);

            if (stats.MinRequiredChanges > maxAllowedChanges)
            {
                return "-1";
            }

            Result result = GetHighestValuePalindrome(stats, maxAllowedChanges);

            IEnumerable<char> digitsAbovePivot = result.Pairs.Select(p => p.DigitAbovePivot);
            IEnumerable<char> digitsBelowPivot = result.Pairs.Reverse().Select(p => p.DigitBelowPivot);
            return new string(digitsAbovePivot.Concat(result.Pivot).Concat(digitsBelowPivot).ToArray());
        }

        /// <summary>
        /// Accumulate statistics about the input
        /// </summary>
        /// <param name="input">Digit string representation of an integer >= 0</param>
        private static Stats GetStats(string input)
        {
            List<Pair> pairs = input.Zip(input.Reverse(), Pair.Create).Take(input.Length / 2).ToList();
            int numMismatchesAtLowerPlaces = 0;
            var pairStatsLowToHigh = new List<PairStats>();
            for (int i = pairs.Count - 1; i >= 0; i--)
            {
                Pair pair = pairs[i];
                pairStatsLowToHigh.Add(new PairStats(pair, numMismatchesAtLowerPlaces));
                numMismatchesAtLowerPlaces += pair.IsMismatch() ? 1 : 0;
            }

            var pairStats = pairStatsLowToHigh.AsEnumerable().Reverse().ToArray();

            int minRequiredChanges = pairStats.Length > 0
                ? pairStats[0].NumMismatchesAtLowerPlaces + (pairStats[0].Pair.IsMismatch() ? 1 : 0)
                : 0;

            char[] pivot = input.Length % 2 == 1
                ? new[] {input[input.Length / 2]}
                : new char[0];
            
            return new Stats(pairStats, pivot, minRequiredChanges);
        }

        /// <summary>
        /// Creates a palindrome of maximal value.
        /// Maximises highest-value places first, and always keeps enough budget spare to fix remaining mismatching pairs.
        /// Precondition: maxAllowedChanges is sufficient to create a palindrome
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="maxAllowedChanges"></param>
        /// <returns>Pairs of digits, and maybe a pivot digit, that (once unpacked to a digit string) maximize the value of the resultant integer</returns>
        private static Result GetHighestValuePalindrome(Stats stats, int maxAllowedChanges)
        {
            int budgetRemaining = maxAllowedChanges;
            var outputPairs = new List<Pair>();
            foreach (PairStats stat in stats.Pairs)
            {
                int budgetForThisPair = budgetRemaining - stat.NumMismatchesAtLowerPlaces;
                if (budgetForThisPair > 0)
                {
                    PairResult pairResult = budgetForThisPair >= 2
                        ? TransformToMax(stat.Pair)
                        : TransformToHigher(stat.Pair);
                    budgetRemaining -= pairResult.CostOfChange;
                    outputPairs.Add(pairResult.Pair);
                }
                else if (stat.Pair.IsMismatch())
                {
                    throw new Exception($"Exhausted budget but still have mismatch: ${stat.Pair}");
                }
                else
                {
                    outputPairs.Add(new Pair(stat.Pair.DigitAbovePivot, stat.Pair.DigitBelowPivot));
                }
            }

            IList<char> outputPivot = stats.Pivot
                .AsEnumerable()
                .Select(c => budgetRemaining > 0 ? '9' : c).ToList();

            return new Result(outputPairs, outputPivot);
        }

        private static PairResult TransformToHigher(Pair pair)
        {
            if (pair.DigitAbovePivot == pair.DigitBelowPivot)
            {
                return new PairResult(new Pair(pair.DigitAbovePivot, pair.DigitBelowPivot), 0);
            }

            int targetDigit = new[] {pair.DigitAbovePivot, pair.DigitBelowPivot}.Select(c => int.Parse(c.ToString())).Max();
            char targetChar = (char) (targetDigit + '0');
            return TransformToChar(targetChar, pair);
        }

        private static PairResult TransformToMax(Pair pair)
        {
            return TransformToChar('9', pair);
        }

        private static PairResult TransformToChar(char targetChar, Pair pair)
        {
            var costOfChange = new[] {pair.DigitAbovePivot, pair.DigitBelowPivot}.Count(c => c != targetChar);
            return new PairResult(new Pair(targetChar, targetChar), costOfChange);
        }
    }
}