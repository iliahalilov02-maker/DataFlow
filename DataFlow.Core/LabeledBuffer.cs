namespace DataFlow.Core;

public class LabeledBuffer : Buffer<string>
{
    public void PrintAllUpper()
    {
        foreach (var text in items)
        {
            Console.WriteLine(text.ToUpper());
        }
    }
}