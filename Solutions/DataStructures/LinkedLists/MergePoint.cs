using System.Collections.Generic;
using System.Linq;

namespace Solutions.DataStructures.LinkedLists
{
    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    /// <summary>
    /// https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
    /// </summary>
    public class MergePoint
    {
        // Complete the findMergeNode function below.

        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        public static int FindMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            var nodes1 = new HashSet<SinglyLinkedListNode>(head1.Nodes());
            return head2.Nodes().First(n => nodes1.Contains(n)).data;
        }
    }

    static class SinglyLinkedListNodeExtensions
    {
        public static IEnumerable<SinglyLinkedListNode> Nodes(this SinglyLinkedListNode head)
        {
            SinglyLinkedListNode node = head;
            do
            {
                yield return node;
                node = node.next;
            } while (node != null);
        }
    }
}