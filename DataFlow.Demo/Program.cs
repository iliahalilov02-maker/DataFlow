using DataFlow.Core;
using DataFlow.Demo;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine(" Блок А: иерархии обобщённых классов ");
var labels = new LabeledBuffer();
labels.TryAdd("привет");
labels.TryAdd("мир");
labels.TryAdd("отчёт");
labels.PrintAllUpper();
Console.WriteLine($"LabeledBuffer.Count = {labels.Count}");

var numbers = new GuardedBuffer<int>(x => x > 0);
Console.WriteLine(numbers.TryAdd(5));
Console.WriteLine(numbers.TryAdd(-3));
Console.WriteLine(numbers.TryAdd(100));
Console.WriteLine($"Count = {numbers.Count}, AcceptedCount = {numbers.AcceptedCount}");

var words = new GuardedBuffer<string>(s => !string.IsNullOrWhiteSpace(s));
Console.WriteLine(words.TryAdd("обобщение"));
Console.WriteLine(words.TryAdd(" "));
Console.WriteLine($"Count = {words.Count}, AcceptedCount = {words.AcceptedCount}");
Console.WriteLine($"Счётчики независимы: numbers.AcceptedCount = {numbers.AcceptedCount}");

Console.WriteLine(" Блок В: обобщённая структура, делегат и метод ");
var temperature = new Record<double>(20, "°C");
Console.WriteLine($"Исходная запись: {temperature}");
var fahrenheit = RecordMapper.Map(temperature, (double c) => c * 9 / 5 + 32, "°F");
Console.WriteLine($"double → double: {fahrenheit}");
var category = RecordMapper.Map(temperature, (double c) => c >= 15 ? "тепло" : "холодно", "Категория");
Console.WriteLine($"double → string: {category}");

Console.WriteLine(" Блок С: обобщённые интерфейсы ");
var products = new InMemoryRepository<Product>();
var apple = new Product { Id = 1, Name = "Яблоко", Price = 120m };
var bread = new Product { Id = 2, Name = "Хлеб", Price = 60m };
products.Add(apple);
products.Add(bread);
Console.WriteLine($"GetById(2) = {products.GetById(2)!.Name}");
Console.WriteLine($"GetById(99) = {(products.GetById(99) is null ? "null" : "ошибка")}");

var customers = new InMemoryRepository<Customer>();
customers.Add(new Customer { Id = 1, Name = "Алина", City = "Казань" });
Console.WriteLine($"GetById(1) у клиентов = {customers.GetById(1)!.Name}");
Console.WriteLine($"products.Count = {products.Count}, customers.Count = {customers.Count}");

var container = new Container<Dog>(new Dog { Name = "Шарик" });
IContainer<Animal> animal = container;
Console.WriteLine($"IContainer<Animal>.GetItem() = {animal.GetItem()}");

Console.WriteLine(" Блок D: методы расширения ");
var nums = new List<int> { 5, 9, 2 };
Console.WriteLine($"FindMax на List<int> = {nums.FindMax()}");
Console.WriteLine($"FindMax на пустом List<string> = {(new List<string>().FindMax() is null ? "null" : "ошибка")}");
Console.WriteLine($"FindMax на пустом List<int> = {new List<int>().FindMax()}");

var catalog = new List<Product>
{
    apple, bread, new Product { Id = 3, Name = "Сыр", Price = 450m }
};
Console.WriteLine($"FindMax на List<Product> = {catalog.FindMax()!.Name}");
nums.PrintAll("Элемент: ");
catalog.PrintAll("Товар: ");