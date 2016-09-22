using System;

class Division
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var divisibleBy2 = 0.00;
        var divisibleBy3 = 0.00;
        var divisibleBy4 = 0.00;

        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            if (currentNumber % 2 == 0)
            {
                divisibleBy2++;
            }
            if (currentNumber % 3 == 0)
            {
                divisibleBy3++;
            }
            if (currentNumber % 4 == 0)
            {
                divisibleBy4++;
            }
        }

        Console.WriteLine("{0:f2}%", divisibleBy2 / n * 100);
        Console.WriteLine("{0:f2}%", divisibleBy3 / n * 100);
        Console.WriteLine("{0:f2}%", divisibleBy4 / n * 100);
    }
}