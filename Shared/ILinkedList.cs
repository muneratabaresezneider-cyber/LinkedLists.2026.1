namespace Shared;

public interface ILinkedList<T>
{
    bool Contains(T data);
    void InsertOrdered(T data);
    void Remove(T data);
    void RemoveAll(T data);
    void SortDescending();
    List<T> GetModes();
    string ToString();
    string ToStringReverse();
}