using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string instruction = "";

            while (instruction != "print")
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();

                instruction = input[0];
                if (instruction== "add")
                {
                    Add(array, input);
                }
                else if (instruction == "addMany")
                {
                    AddMany(array, input);
                }
                else if (instruction == "contains")
                {
                    Contains(array, input);
                }
                else if (instruction == "remove")
                {
                    Remove(array, input);
                }
                else if (instruction == "shift")
                {
                    Shift(array, input);
                }
                else if (instruction == "sumPairs")
                {
                    SumPairs(array, input);
                }
                else if (instruction == "print")
                {
                    Print(array);
                    break;
                }                             
            }
            
        }
        static void Add(List<int> list, List<string> input)
        {
            int possition = int.Parse(input[1]);
            int number = int.Parse(input[2]);
            list.Insert(possition,number);
        }
        static void AddMany(List<int> list, List<string> input)
        {
            int possition = int.Parse(input[1]);
            List<int> listToAdd = new List<int>();

            for (int i = 2; i<input.Count; i++)
            {
                listToAdd.Add(int.Parse(input[i]));
            }
            list.InsertRange(possition,listToAdd);
        }
        static void Contains(List<int> list, List<string> input)
        {
            bool isContain = false;
            int number = int.Parse(input[1]);
            for (int i = 0; i<list.Count; i++)
            {
                if (list[i]==number)
                {
                    isContain = true;
                    Console.WriteLine(i);
                    break;
                }
            }
            if (!isContain)
            {
                Console.WriteLine("-1");
            }
        }
        static void Remove(List<int> list, List<string> input)
        {
            int possition = int.Parse(input[1]);
            list.RemoveAt(possition);
        }
        static void Shift(List<int> list, List<string> input)
        {
            int shiftCount = int.Parse(input[1]);
            int temp = 0;
            for (int i = 0; i<shiftCount; i++)
            {
                temp = list[0];
                list.RemoveAt(0);
                list.Add(temp);
            }
        }
        static void SumPairs(List<int> list, List<string> input)
        {          
            for (int i = 1; i < list.Count; i+=2)
            {
                list[i - 1] += list[i];               
            }           
            for (int i = 1; i < list.Count; i ++)
            {
                list.RemoveAt(i);
            }
        }
        static void Print(List<int> list)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", list));
            Console.Write("]");
        }
    }
}
