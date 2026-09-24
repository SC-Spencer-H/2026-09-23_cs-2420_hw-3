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

        // This one is very simple. I just start at the head, walk through the entire list, and swap the next and prev pointers of every node.
        // I store a reference to next before I do so I can keep walking forward in the right direction. Once current == null, I know I've walked off the 
        // end of the list and I can stop. Then I just need to swap the head and tail of the list.
        // This should be O(n), since we are looping through the entire list exactly once. Space complexity should be O(1), since we're reversing in-place.
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

        // Here I'm effectively making two new lists, since I store a head and tail for each of them. I walk through the entire list and add each node
        // to the end of the appropriate list. At the end, I connect the two lists end to end, cutting out the dummy heads at the beginning, and update
        // the actual head and tail.
        // Time complexity should also be O(n), since we're looping through exactly once. Even though we're kind of making two new lists, we only actually make
        // on new node for each, otherwise we're just playing with pointers, so it's still O(1) space complexity. 
        public void Partition(int value)
        {
            DoubleLinkedNode node = Head;

            DoubleLinkedNode lessHead = new(0);
            DoubleLinkedNode lessTail = lessHead;
            DoubleLinkedNode greaterHead = new(0);
            DoubleLinkedNode greaterTail = greaterHead;

            while (node != null)
            {
                if (node.Value < value)
                {
                    lessTail.Next = node;
                    node.Previous = lessTail;
                    lessTail = node;
                }
                else
                {
                    greaterTail.Next = node;
                    node.Previous = greaterTail;
                    greaterTail = node;
                }

                node = node.Next;
            }

            lessTail.Next = greaterHead.Next;
            greaterHead.Previous = lessTail;
            lessHead.Previous = null;
            greaterTail.Next = null;
            Head = lessHead.Next;
            Tail = greaterTail;
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