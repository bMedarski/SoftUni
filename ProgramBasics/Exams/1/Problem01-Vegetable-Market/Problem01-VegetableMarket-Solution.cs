using System;

class VegetableMarket
{
    static void Main()
    {
        var vegInLv = double.Parse(Console.ReadLine());
        var fruitsInLv = double.Parse(Console.ReadLine());

        var vegPerKg = int.Parse(Console.ReadLine());
        var fruitsPerKg = int.Parse(Console.ReadLine());

        Console.WriteLine((vegInLv * vegPerKg + fruitsPerKg * fruitsInLv) / 1.94);
    }
}