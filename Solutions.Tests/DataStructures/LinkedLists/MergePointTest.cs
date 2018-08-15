using System.Linq;
using NUnit.Framework;
using Solutions.DataStructures.LinkedLists;

namespace Solutions.Tests.DataStructures.LinkedLists
{
    [TestFixture]
    public class MergePointTest
    {
        [TestCase(
            new[] {1},
            new[] {1},
            new[] {2, 3},
            ExpectedResult = 2
        )]
        [TestCase(
            new[] {1, 2},
            new[] {1},
            new[] {3},
            ExpectedResult = 3
        )]
        [TestCase(
            new[] {1, 2, 3, 4},
            new[] {1, 2, 3, 4},
            new[] {5, 6, 7, 8},
            ExpectedResult = 5
        )]
        public int FindMergeNode_ForTwoLists_ReturnsDataFromFirstSharedNode(
            int[] firstIndices,
            int[] secondIndices,
            int[] sharedIndices
        )
        {
            TestSinglyLinkedList onlyFirst = SinglyLinkedListHelper.CreateLinkedList(firstIndices);
            TestSinglyLinkedList onlySecond = SinglyLinkedListHelper.CreateLinkedList(secondIndices);
            TestSinglyLinkedList onlyShared = SinglyLinkedListHelper.CreateLinkedList(sharedIndices);

            SinglyLinkedListNode firstHead = ConcatLists(onlyFirst, onlyShared);
            SinglyLinkedListNode secondHead = ConcatLists(onlySecond, onlyShared);

            return MergePoint.FindMergeNode(firstHead, secondHead);
        }

        private static SinglyLinkedListNode ConcatLists(TestSinglyLinkedList first, TestSinglyLinkedList second)
        {
            SinglyLinkedListHelper.JoinNodes(new[] {first.Last, second.Head});
            return first.Head;
        }
    }
}