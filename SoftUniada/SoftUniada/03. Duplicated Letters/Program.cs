using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Duplicated_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> input = Console.ReadLine().ToList<char>(); ;

            bool isAnyDuplicate = true;
            int counter = 0;
            while (isAnyDuplicate)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if (i == input.Count - 1)
                    {
                        isAnyDuplicate = false;
                        break;
                    }
                    if (input[i]==input[i+1])
                    {
                        input.RemoveAt(i);
                        input.RemoveAt(i);
                        counter++;
                        break;
                    }                  
                }
                if (input.Count == 0)
                {
                    isAnyDuplicate = false;
                    break;
                }
            }
            if (input.Count==0)
            {
                Console.WriteLine("Empty String");
            }
            else
            {
                Console.WriteLine(string.Join("",input));
            }
            Console.WriteLine($"{counter} operations");


            

        }
    }
}
