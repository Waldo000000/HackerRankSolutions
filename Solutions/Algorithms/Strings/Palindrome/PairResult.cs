namespace Solutions.Algorithms.Strings.Palindrome
{
    internal class PairResult
    {
        public Pair Pair { get; }
        public int CostOfChange { get; }

        public PairResult(Pair pair, int costOfChange)
        {
            Pair = pair;
            CostOfChange = costOfChange;
        }
    }
}