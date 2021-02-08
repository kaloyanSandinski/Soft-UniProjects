using System;

namespace CustomDoublyLinkedList
{
    public class MyLinkedList
    {
        private int count = 0;
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddHead(Node currNode)
        {
            count++;
            if (Head == null)
            {
                Head = currNode;
                Tail = currNode;
                return;
            }
            currNode.Next = Head;
            Head.Pervious = currNode;
            Head = currNode;
        }

        public void AddTail(Node currNode)
        {
            count++;
            if (Tail==null)
            {
                Head = currNode;
                Tail = currNode;
                return;
            }

            currNode.Pervious = Tail;
            Tail.Next = currNode;
            Tail = currNode;
        }

        public Node RemoveHead()
        {
            if (Head==null)
            {
                return null; 
            }

            count--;
            
            var nodeToReturn = Head;
            if (Head.Next!=null)
            {
                Head = Head.Next;
                Head.Pervious = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }
            
            return nodeToReturn;
        }

        public Node RemoveTail()
        {
            if (Tail==null)
            {
                return null;
            }

            count--;
            
            var nodeToReturn = Tail ;
            if (Tail.Pervious!=null)
            {
                Tail = Tail.Pervious;
                Tail.Next = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return nodeToReturn;
        }

        public void ForEachFromHead(Action<Node>action)
        {
            Node currNode = Head;
            while (currNode!=null)
            {
                action(currNode);
                currNode = currNode.Next;
            }
        }

        public void ForEachFromTail(Action<Node> action)
        {
            Node currNode = Tail;
            while (currNode!=null)
            {
                action(currNode);
                currNode = currNode.Pervious;
            }
        }

        public int[] ToArray()
        {
            int[] output  = new int[count];
            Node currNode = Head;
            for (int i = 0; i < count; i++)
            {
                output[i] = currNode.Value;
                currNode = currNode.Next;
            }

            return output;
        }
    }
}