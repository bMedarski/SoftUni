using System;

class Program
{
    static void Main()
    {
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        string operation = Console.ReadLine();

        if (operation == "+")
        {
            Console.Write($"{number1} + {number2} = {number1 + number2} - ");
            Console.WriteLine((number1 + number2) % 2 == 0 ? "even" : "odd");
        }
        else if (operation == "-")
        {
            Console.Write($"{number1} - {number2} = {number1 - number2} - ");
            Console.WriteLine((number1 - number2) % 2 == 0 ? "even" : "odd");
        }
        else if (operation == "*")
        {
            Console.Write($"{number1} * {number2} = {number1 * number2} - ");
            Console.WriteLine((number1 * number2) % 2 == 0 ? "even" : "odd");
        }
        else if (operation == "/")
        {
            Console.WriteLine(number2 == 0
                ? $"Cannot divide {number1} by zero"
                : $"{number1} / {number2} = {(double)number1 / number2}");
        }
        else if (operation == "%")
        {
            Console.WriteLine(number2 == 0
                ? $"Cannot divide {number1} by zero"
                : $"{number1} % {number2} = {number1 % number2}");
        }
    }
}
