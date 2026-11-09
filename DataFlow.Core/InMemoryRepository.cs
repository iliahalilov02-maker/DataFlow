namespace DataFlow.Core;

public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> items = new();
    public int Count => items.Count;

    public void Add(T item) => items.Add(item);

    public T? GetById(int id)
    {
        foreach (var item in items)
        {
            if (item.Id == id) return item;
        }
        return default;
    }
}