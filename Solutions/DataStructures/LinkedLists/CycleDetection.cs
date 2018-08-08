using System.Collections.Generic;

namespace Solutions.DataStructures.LinkedLists
{
    public class SinglyLinkedListNode
    {
        // ReSharper disable once InconsistentNaming
        public int data;
        // ReSharper disable once InconsistentNaming
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            data = nodeData;
            next = null;
        }
    }

    /// <summary>
    /// https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle/problem
    /// </summary>
    public class CycleDetection
    {
        public static bool HasCycle(SinglyLinkedListNode head)
        {
            var nodes = new HashSet<SinglyLinkedListNode>();
            do
            {
                if (nodes.Contains(head))
                {
                    return true;
                }

                nodes.Add(head);
                head = head.next;
            } while (head != null);

            return false;
        }
    }
}