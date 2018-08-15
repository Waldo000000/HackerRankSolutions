using System;
using System.Collections.Generic;
using System.Linq;
using Solutions.DataStructures.LinkedLists;

namespace Solutions.Tests.DataStructures.LinkedLists
{
    internal class TestSinglyLinkedList
    {
        public readonly SinglyLinkedListNode Head;
        public readonly SinglyLinkedListNode Last;

        public TestSinglyLinkedList(SinglyLinkedListNode head, SinglyLinkedListNode last)
        {
            Head = head;
            Last = last;
        }
    }
    internal static class SinglyLinkedListHelper
    {
        /// <summary>
        /// Creates list from an integer representation.
        /// e.g. new [] { 1, 2, 3, 0, 1 } creates a cyclic list (i.e. node "0" links back to head node "1".
        /// Data of the node is equal to the value specified in indices. 
        /// </summary>
        public static TestSinglyLinkedList CreateLinkedList(int[] indices)
        {
            List<SinglyLinkedListNode> nodes = CreateUnlinkedNodes(indices.Max() + 1);
            JoinNodes(indices.Select(i => nodes[i]).ToList());
            return new TestSinglyLinkedList(nodes[indices[0]], nodes.Last());
        }

        public static List<SinglyLinkedListNode> CreateUnlinkedNodes(int count)
        {
            return Enumerable.Range(0, count).Select(CreateNode).ToList();
        }

        private static SinglyLinkedListNode CreateNode(int data)
        {
            return new SinglyLinkedListNode(data);
        }

        /// <summary>
        /// Returns head of list
        /// </summary>
        public static void JoinNodes(IList<SinglyLinkedListNode> nodes)
        {
            IEnumerable<Tuple<SinglyLinkedListNode, SinglyLinkedListNode>> nodePairs = nodes.Zip(nodes.Skip(1), Tuple.Create);
            foreach (var nodePair in nodePairs)
            {
                nodePair.Item1.next = nodePair.Item2;
            }
        }
    }
}