namespace DataFlow.Core;

public readonly struct Record<T>
{
    public T Value { get; }
    public string Label { get; }
    public Record(T value, string label)
    {
        Value = value;
        Label = label;
    }
    public override string ToString() => $"{Label}: {Value}";
}

public delegate TResult Mapper<T, TResult>(T value);

public static class RecordMapper
{
    public static Record<TResult> Map<T, TResult>(
        Record<T> source, Mapper<T, TResult> mapper, string label)
    {
        return new Record<TResult>(mapper(source.Value), label);
    }
}