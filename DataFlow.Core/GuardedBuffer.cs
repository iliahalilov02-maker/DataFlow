namespace DataFlow.Core;

public class GuardedBuffer<T> : Buffer<T>
{
    private readonly Func<T, bool> isAllowed;
    public int AcceptedCount { get; private set; }

    public GuardedBuffer(Func<T, bool> isAllowed)
    {
        this.isAllowed = isAllowed;
    }

    public override bool TryAdd(T item)
    {
        if (!isAllowed(item))
        {
            Console.WriteLine($"Отклонено: {item}");
            return false;
        }
        bool added = base.TryAdd(item);
        if (added)
        {
            AcceptedCount++;
        }
        Console.WriteLine($"Добавлено: {item}");
        return added;
    }
}