namespace Solutions.Algorithms.Strings.Palindrome
{
    internal class Pair
    {
        public char DigitAbovePivot { get; }
        public char DigitBelowPivot { get; }

        public Pair(char digitAbovePivot, char digitBelowPivot)
        {
            DigitAbovePivot = digitAbovePivot;
            DigitBelowPivot = digitBelowPivot;
        }

        public static Pair Create(char digitAbovePivot, char digitBelowPivot)
        {
            return new Pair(digitAbovePivot, digitBelowPivot);
        }

        public bool IsMismatch()
        {
            return DigitAbovePivot != DigitBelowPivot;
        }
    }
}