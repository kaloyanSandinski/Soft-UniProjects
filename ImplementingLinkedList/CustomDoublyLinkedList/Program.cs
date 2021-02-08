using System;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node node = new Node(1);
            //Node node2 = new Node(2);
            //Node node3 = new Node(3);
            //Node node4 = new Node(4);
            //node.Next = node2;
            //node2.Next = node3;
            //node3.Next = node4;
            MyLinkedList linkedList = new MyLinkedList();
            Console.WriteLine($"Remove empty head: {linkedList.RemoveHead()}");
            for (int i = 0; i <= 10; i++)
            {
                linkedList.AddHead(new Node(i));
            }

            for (int i = 0; i <=10; i++)
            {
                linkedList.AddTail(new Node(i));
            }

            //Console.WriteLine($"removed head: {linkedList.RemoveHead().Value}");
            //Console.WriteLine($"removed head: {linkedList.RemoveHead().Value}");
            //Console.WriteLine($"removed tail: {linkedList.RemoveTail().Value}");
            //Console.WriteLine($"removed tail: {linkedList.RemoveTail().Value}");
            //Console.WriteLine($"removed tail: {linkedList.RemoveTail().Value}");
            //linkedList.ForEachFromHead((node) =>
            //{
            //    Console.WriteLine($"From head: {node.Value}");
            //});
            //linkedList.ForEachFromTail(node =>
            //{
            //    Console.WriteLine($"From tail {node.Value}");
            //});
            int[] output = linkedList.ToArray();
            foreach (var element in output)
            {
                Console.WriteLine(element);
            }
        }
    }
}