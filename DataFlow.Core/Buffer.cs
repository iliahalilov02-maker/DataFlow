namespace DataFlow.Core;

public class Buffer<T>
{
    protected readonly List<T> items = new();
    public int Count => items.Count;
    public virtual bool TryAdd(T item)
    {
        items.Add(item);
        return true;
    }
}