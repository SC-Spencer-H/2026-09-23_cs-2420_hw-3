using HW3;

internal class Program
{
    static void Main()
    {
        DoubleLinkedList reverse = new([3, 8, 12, 5]);
        Console.WriteLine(reverse);
        reverse.Reverse();
        Console.WriteLine(reverse);

        DoubleLinkedList partition = new([3, 8, 5, 2, 10, 1]);
        Console.WriteLine(partition);
        partition.Partition(5);
        Console.WriteLine(partition);

        partition = new([3, 8, 5, 2, 10, 1]);
        partition.Partition(11);
        Console.WriteLine(partition);
        
        partition = new([3, 8, 5, 2, 10, 1]);
        partition.Partition(0);
        Console.WriteLine(partition);
    }
}