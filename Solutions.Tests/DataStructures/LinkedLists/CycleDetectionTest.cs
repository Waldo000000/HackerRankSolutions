using System;
using System.Collections.Generic;
using System.Linq;
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
            SinglyLinkedListNode head = CreateLinkedList(indices);
            return CycleDetection.HasCycle(head);
        }

        private SinglyLinkedListNode CreateLinkedList(int[] indices)
        {
            List<SinglyLinkedListNode> nodes = Enumerable.Range(0, indices.Max() + 1).Select(CreateNode).ToList();
            SinglyLinkedListNode head = JoinNodes(indices.Select(i => nodes[i]).ToArray());
            return head;
        }

        private static SinglyLinkedListNode CreateNode(int data)
        {
            return new SinglyLinkedListNode(data);
        }

        /// <summary>
        /// Returns head of list
        /// </summary>
        private SinglyLinkedListNode JoinNodes(params SinglyLinkedListNode[] nodes)
        {
            var nodePairs = nodes.Zip(nodes.Skip(1), Tuple.Create);
            foreach (var nodePair in nodePairs)
            {
                nodePair.Item1.next = nodePair.Item2;
            }

            return nodes[0];
        }
    }
}