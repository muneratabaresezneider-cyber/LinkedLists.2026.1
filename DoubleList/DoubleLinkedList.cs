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

        // Si es string, comparar solo por primera letra
        if (typeof(T) == typeof(string))
        {
            string dataStr = (data as string) ?? string.Empty;
            char firstCharData = dataStr.Length > 0 ? char.ToUpper(dataStr[0]) : char.MinValue;

            while (current != null)
            {
                string currentStr = (current.Data as string) ?? string.Empty;
                char firstCharCurrent = currentStr.Length > 0 ? char.ToUpper(currentStr[0]) : char.MinValue;

                if (firstCharCurrent.CompareTo(firstCharData) < 0)
                    current = current.Next;
                else
                    break;
            }
        }
        else
        {
            // Comparación normal para otros tipos
            while (current != null && current.Data!.CompareTo(data) < 0)
            {
                current = current.Next;
            }
        }

        if (current == _head)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        else if (current == null)
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
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

    public void SortDescending()
    {
        if (_head == null || _head.Next == null)
            return;

        if (typeof(T) == typeof(string))
        {
            var sorted = false;
            while (!sorted)
            {
                sorted = true;
                var current = _head;
                while (current != null && current.Next != null)
                {
                    string currentStr = (current.Data as string) ?? string.Empty;
                    string nextStr = (current.Next.Data as string) ?? string.Empty;

                    char firstCharCurrent = currentStr.Length > 0 ? char.ToUpper(currentStr[0]) : char.MinValue;
                    char firstCharNext = nextStr.Length > 0 ? char.ToUpper(nextStr[0]) : char.MinValue;

                    if (firstCharCurrent.CompareTo(firstCharNext) < 0)
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
        else
        {
            var sorted = false;
            while (!sorted)
            {
                sorted = true;
                var current = _head;
                while (current != null && current.Next != null)
                {
                    if (current.Data!.CompareTo(current.Next.Data) < 0)
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