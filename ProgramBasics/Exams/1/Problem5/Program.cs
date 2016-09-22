using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i<n; i++)
            {
                for (int j = 0; j<5*n; j++)
                {
                    if ((j==3*n)||(j==3*n+1+i))
                    {
                        Console.Write("*");
                    }else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < (n/2); i++)
            {
                for (int j = 0; j < 5 * n; j++)
                {
                    
                        if (j<=3*n||j==3*n+n)
                        {
                            Console.Write("*");

                        }
                        else
                        {
                            Console.Write("-");
                        }                 
                }
                Console.WriteLine();
            }
            for (int i = 0; i < (n / 2); i++)
            {
                for (int j = 0; j < 5 * n; j++)
                {

                    if (i == n / 2 - 1)
                    {
                        if (j > 3 * n - 1 - i && j < 3 * n + n + 1 + i)
                        {
                            Console.Write("*");

                        }
                        else
                        {
                            Console.Write("-");
                        }

                    }
                    else
                    {
                        if (j == 3 * n - i || j == 3 * n + n + i)
                        {
                            Console.Write("*");

                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
              
                }
                Console.WriteLine();
            }
        }
    }
}
