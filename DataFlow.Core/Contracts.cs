namespace DataFlow.Core;

public interface IEntity
{
    int Id { get; }
}

public interface IRepository<T> where T : IEntity
{
    int Count { get; }
    void Add(T item);
    T? GetById(int id);
}

public interface IContainer<out T>
{
    T GetItem();
}