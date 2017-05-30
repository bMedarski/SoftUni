using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {

            ulong number = ulong.Parse(Console.ReadLine());
            if (number == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
              ulong secondNum = 1;
                ulong firstNum = 0;
                ulong current = 0;
            for (ulong i = 1; i < number; i++)
            {
                current = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = current;
                //Console.WriteLine(current);
            }
            Console.WriteLine(current);  
            }
            
        }
    }
}
