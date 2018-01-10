using System;

class TileRepairment
{
    static void Main(string[] args)
    {
        double n = double.Parse(Console.ReadLine());
        double w = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        double area = n * n;
        double areaToRepair = area - (a * b);

        double tiles = areaToRepair / (w * h);

        double minutes = tiles * 0.2;

        Console.WriteLine(tiles);
        Console.WriteLine(minutes);
        
    }
}

