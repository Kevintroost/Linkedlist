using System;
using System.Collections.Generic;



#nullable enable

public interface IMyList<T>
{
    void Clear();
    void Add(T element);
    int IndexOf(T element);
    bool Contains(T element);
    void Insert(int index, T element);
    void Remove(T element);
    void RemoveAt(int index);
    T this[int index] { get; set; }
    int Count { get; }
}

public class MyLinkedList<T> : IMyList<T>
{
    private class Node
    {
        public T Data;
        public Node? Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node? head;
    private int count;

    public MyLinkedList()
    {
        head = null;
        count = 0;
    }

    public void Clear()
    {
        head = null;
        count = 0;
    }

    public void Add(T element)
    {
        Node newNode = new Node(element);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    public int IndexOf(T element)
    {
        Node? current = head;
        int index = 0;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, element))
            {
                return index;
            }
            current = current.Next;
            index++;
        }
        return -1;
    }

    public bool Contains(T element)
    {
        return IndexOf(element) != -1;
    }

    public void Insert(int index, T element)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node newNode = new Node(element);
        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head!;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        count++;
    }

    public void Remove(T element)
    {
        if (head == null) return;

        if (EqualityComparer<T>.Default.Equals(head.Data, element))
        {
            head = head.Next;
            count--;
            return;
        }

        Node current = head;
        while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, element))
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            count--;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (index == 0)
        {
            head = head!.Next;
        }
        else
        {
            Node current = head!;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }
            current.Next = current.Next!.Next;
        }
        count--;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            return current.Data;
        }
        set
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            current.Data = value;
        }
    }

    public int Count => count;
}
