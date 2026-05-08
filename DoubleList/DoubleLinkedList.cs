using Shared;

namespace DoubleList;

public class DoubleLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
                return true;
            current = current.Next;
        }
        return false;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
    }

    public void InsertAtEnding(T data)
    {
        var newNode = new Node<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
    }

    public void InsertOrdered(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && current.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        if (current == _head)
        {
            InsertAtBeginning(data);
        }
        else if (current == null)
        {
            InsertAtEnding(data);
        }
        else
        {
            newNode.Next = current;
            newNode.Previous = current.Previous;
            current.Previous!.Next = newNode;
            current.Previous = newNode;
        }
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head && current == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Previous = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;
                    _tail!.Next = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAll(T data)
    {
        var current = _head;
        while (current != null)
        {
            var next = current.Next;
            if (current.Data!.Equals(data))
            {
                if (current == _head && current == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else if (current == _head)
                {
                    _head = _head.Next;
                    _head!.Previous = null;
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;
                    _tail!.Next = null;
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
            }
            current = next;
        }
    }

    public void Reverse()
    {
        var current = _head;
        while (current != null)
        {
            var temp = current.Next;
            current.Next = current.Previous;
            current.Previous = temp;
            current = temp;
        }

        var tempNode = _head;
        _head = _tail;
        _tail = tempNode;
    }

    public void Sort()
    {
        if (_head == null || _head.Next == null)
            return;

        var sorted = false;
        while (!sorted)
        {
            sorted = true;
            var current = _head;
            while (current != null && current.Next != null)
            {
                if (current.Data!.CompareTo(current.Next.Data) > 0)
                {
                    var temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    sorted = false;
                }
                current = current.Next;
            }
        }
    }

    public void SortDescending()
    {
        Sort();
        Reverse();
    }

    public List<T> GetModes()
    {
        var modes = new List<T>();
        var current = _head;

        if (current == null)
            return modes;

        var frequencies = new Dictionary<T, int>();
        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data!))
                frequencies[current.Data!] += 1;
            else
                frequencies[current.Data!] = 1;
            current = current.Next;
        }

        var maxFrequency = 0;
        foreach (var freq in frequencies.Values)
        {
            if (freq > maxFrequency)
                maxFrequency = freq;
        }

        foreach (var kvp in frequencies)
        {
            if (kvp.Value == maxFrequency)
                modes.Add(kvp.Key);
        }

        modes.Sort();
        return modes;
    }

    public string GetChart()
    {
        var chart = string.Empty;
        var frequencies = new Dictionary<T, int>();
        var current = _head;

        if (current == null)
            return chart;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data!))
                frequencies[current.Data!] += 1;
            else
                frequencies[current.Data!] = 1;
            current = current.Next;
        }

        var sortedFrequencies = frequencies.OrderBy(x => x.Key);
        foreach (var kvp in sortedFrequencies)
        {
            chart += $"{kvp.Key} ";
            for (int i = 0; i < kvp.Value; i++)
                chart += "*";
            chart += "\n";
        }

        return chart;
    }

    override public string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} <-> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }

    public string ToStringReverse()
    {
        var current = _tail;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} <-> ";
            current = current.Previous;
        }
        result += "null";
        return result;
    }

    public bool IsEmpty()
    {
        return _head == null;
    }
}