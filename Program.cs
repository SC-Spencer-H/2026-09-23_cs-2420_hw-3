using HW3;

internal class Program
{
    static void Main()
    {
        DoubleLinkedList reverse = new([3, 8, 12, 5]);
        Console.WriteLine(reverse);
        reverse.Reverse();
        Console.WriteLine(reverse);
    }
}