using NUnit.Framework;
using Solutions.DataStructures.LinkedLists;

namespace Solutions.Tests.DataStructures.LinkedLists
{
    [TestFixture]
    public class CycleDetectionTest
    {
        [TestCase(new[] {0}, ExpectedResult = false)]
        [TestCase(new[] {0, 1, 2}, ExpectedResult = false)]
        [TestCase(new[] {0, 1, 0}, ExpectedResult = true)]
        [TestCase(new[] {0, 1, 2, 3, 0}, ExpectedResult = true)]
        public bool CycleDetection_ForGivenListOfNodeLinks_ReturnsTrueIfHasCycle(int[] indices)
        {
            SinglyLinkedListNode head = SinglyLinkedListHelper.CreateLinkedList(indices).Head;
            return CycleDetection.HasCycle(head);
        }
    }
}