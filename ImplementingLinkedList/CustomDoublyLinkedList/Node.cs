namespace CustomDoublyLinkedList
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Pervious { get; set; }
    }
}