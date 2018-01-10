using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int firstNum = n / 100;
            int secondNum = n % 100 / 10;
            int thirdNum = n % 10;

            int countRows = firstNum + secondNum;
            int countCols = firstNum + thirdNum;

            int currentNum = n;
            for (int i = 0; i<countRows; i++)
            {
                

                for (int j = 0; j<countCols; j++)
                {
                    

                    if (currentNum%5==0)
                    {
                        currentNum = currentNum - firstNum;
                    }
                    else if (currentNum%3==0)
                    {
                        currentNum = currentNum - secondNum;
                    }
                    else
                    {
                        currentNum = currentNum + thirdNum;
                    }
                    Console.Write("{0} ",currentNum);
                }
                Console.WriteLine();
            }
        }
    }
}
