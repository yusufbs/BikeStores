// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


var data = Enumerable.Range(1, 20).Select(x => SomeMethod(x)).ToList();

foreach (var item in data)
    Console.WriteLine(item);

string SomeMethod(int x)
{
    if (x % 15 == 0) return "FizzBuzz";
    if (x % 3 == 0) return "Fizz";
    if (x % 5 == 0) return "Buzz";
    return x.ToString();
}