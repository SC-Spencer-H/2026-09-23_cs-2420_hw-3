namespace HW3
{
    public class DoubleLinkedList
    {
        private DoubleLinkedNode Head { get; set; }
        private DoubleLinkedNode Tail { get; set; }
        public int Count { get; private set; } = 0;

        public DoubleLinkedList(int[] values)
        {
            foreach (int value in values)
                Add(value);
        }

        public void Add(int value)
        {
            DoubleLinkedNode node = new(value);

            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Count++;
        }

        public void Reverse()
        {
            DoubleLinkedNode current = Head;
            DoubleLinkedNode next;
            
            while (current != null)
            {
                next = current.Next;
                current.Next = current.Previous;
                current.Previous = next;
                current = next;
            }

            (Head, Tail) = (Tail, Head);
        }

        public override string ToString()
        {
            string asString = "[";
            DoubleLinkedNode node = Head;

            if (node == null)
            {
                asString += "]";
                return asString;
            }
            else
            {
                asString += node.Value;
            }

            while (node.Next != null)
            {
                asString += ",";
                asString += node.Next.Value;
                node = node.Next;
            }

            asString += "]";
            return asString;
        }
    }
}