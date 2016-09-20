using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command = Console.ReadLine();

        while (!command.Equals("stop"))
        {
            //string line = Console.ReadLine().Trim();
            int[] args = new int[2];
            string[] stringParams = command.Split(ArgumentsDelimiter);
            if (stringParams[0].Equals("add") ||
                stringParams[0].Equals("subtract") ||
                stringParams[0].Equals("multiply"))
            {
                

               
                args[0] = int.Parse(stringParams[1]);
                args[1] = int.Parse(stringParams[2]);
                PerformAction(array, stringParams[0], args);
            }
            else
            {
               
                args[0] = 0;
                args[1] = 0;
                PerformAction(array, stringParams[0], args);
            }

            

            PrintArray(array);
            Console.WriteLine();

            command = Console.ReadLine();
        }
    }

    static void PerformAction(long[] arr, string action, int[] args)
    {
        long[] array = arr;
        int pos = args[0];
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos-1] *= value;
                break;
            case "add":
                array[pos-1] += value;
                break;
            case "subtract":
                array[pos-1] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                break;
            case "rshift":
                ArrayShiftRight(array);
                break;
        }
    }

    private static void ArrayShiftRight(long[] array)
    {
        var last = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = last;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        var first = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = first;
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
