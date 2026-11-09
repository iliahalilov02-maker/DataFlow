namespace DataFlow.Demo;

using DataFlow.Core;

public abstract class Animal
{
    public string Name { get; set; } = "";
    public override string ToString() => $"{GetType().Name} по имени {Name}";
}

public sealed class Dog : Animal { }

public sealed class Product : IEntity, IComparable<Product>
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    public int CompareTo(Product? other)
    {
        if (other is null) return 1;
        return Price.CompareTo(other.Price);
    }

    public override string ToString() => $"{Name} ({Price:0.00})";
}

public sealed class Customer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string City { get; set; } = "";
}