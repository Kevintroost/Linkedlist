using System;


class Program
{
    public static void RunDemo()
    {
        MyLinkedList<int> myList = new MyLinkedList<int>();

        myList.Add(10);
        myList.Add(20);
        myList.Add(30);

        Console.WriteLine("Lijst na toevoegen van 10, 20, 30:");
        PrintList(myList);

        Console.WriteLine($"Element op index 1: {myList[1]}");
        Console.WriteLine($"Index van 20: {myList.IndexOf(20)}");

        myList.Remove(20);
        Console.WriteLine("Lijst na verwijderen van 20:");
        PrintList(myList);

        myList.Insert(1, 25);
        Console.WriteLine("Lijst na invoegen van 25 op index 1:");
        PrintList(myList);

        Console.WriteLine($"Bevat 10? {myList.Contains(10)}");

        myList.RemoveAt(0);
        Console.WriteLine("Lijst na verwijderen van element op index 0:");
        PrintList(myList);

        myList.Clear();
        Console.WriteLine($"Aantal elementen na Clear(): {myList.Count}");
    }

    static void PrintList(MyLinkedList<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }
}
