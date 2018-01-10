using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Football_League
{
    class Program
    {
        static void Main(string[] args)
        {

            long health = long.Parse(Console.ReadLine());
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            int j = 0;

            for (int i = 0; i<cols; i++)
            {
                if (j==0)
                {
                    for (j = 0; j < rows; j++)
                    {
                       
                    }
                }else
                {
                    for (j = rows-1; j>=0; j--)
                    {

                    }
                }

                

            }

        }
    }
}
