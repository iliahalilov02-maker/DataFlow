namespace DataFlow.Core;

public static class CollectionExtensions
{
    public static void PrintAll<T>(this IEnumerable<T> source, string prefix)
    {
        foreach (var item in source)
            Console.WriteLine($"{prefix}{item}");
    }

    public static T? FindMax<T>(this IEnumerable<T> source) where T : IComparable<T>
    {
        T? best = default;
        bool found = false;
        foreach (var item in source)
        {
            if (!found || item.CompareTo(best!) > 0)
            {
                best = item;
                found = true;
            }
        }
        return found ? best : default;
    }
}