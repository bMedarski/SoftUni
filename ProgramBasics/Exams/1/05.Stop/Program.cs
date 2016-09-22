using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Stop
{
    class Program
    {
        static void Main(string[] args)
        {

            byte n = byte.Parse(Console.ReadLine());

            int length = (4 * n)+3;

            for (byte i = 0; i <= n; i++)
            {
                for (byte j = 0; j < length; j++)
                {
                    if (i==0)
                    {
                        if ((j <= n) || (j > 3 * n + 1))
                        {
                            Console.Write(".");

                        }
                        else
                        {
                            Console.Write("_");
                        }
                    }
                    else
                    {
                        if ((j <= n - i) || (j > length - n - 2 + i))
                        {
                            Console.Write(".");

                        }
                        else
                        {
                            if (j == n - i+2 || j == n - i + 1)
                            {
                                Console.Write("/");
                            }
                            else if ((j == length - n - 3 + i) || (j == length - n - 2 + i))
                            {
                                Console.Write("\\");
                            }
                            else
                            {
                                Console.Write("_");
                            }

                        }
                    }
                   

                }
                Console.WriteLine();
            }

            for (byte i = 0; i <= 1; i++)
            {
                for (byte j = 0; j < length; j++)
                {
                    if (i == 0)
                    {


                        if ((j <= 1))
                        {
                            Console.Write("/");

                        }
                        else if (j >= length - 2)
                        {
                            Console.Write("\\");
                        }
                        else if (j == length / 2)
                        {
                            Console.Write("O");
                        }
                        else if (j == (length / 2))
                        {
                            Console.Write("O");
                        }
                        else if (j == (length / 2) - 1)
                        {
                            Console.Write("T");
                        }
                        else if (j == (length / 2) - 2)
                        {
                            Console.Write("S");
                        }
                        else if (j == (length / 2) + 1)
                        {
                            Console.Write("P");
                        }
                        else if (j == (length / 2) + 2)
                        {
                            Console.Write("!");
                        }
                        else
                        {
                            Console.Write("_");
                        }
                    }
                    else
                    {
                        if (j <= 1)
                        {
                            Console.Write("\\");

                        }
                        else if (j >= length - 2)
                        {
                            Console.Write("/");
                        }
                        else
                        {
                            Console.Write("_");

                        }
                    }

                }
                Console.WriteLine();
            }
           
            for (byte i = 0; i < n-1; i++)
            {
                for (byte j = 0; j < length; j++)
                {
                    if ((j <= i)||(j>=length-i-1))
                    {
                        Console.Write(".");

                    }else if ((j==i+1)|(j==i+2))
                    {
                        Console.Write("\\");
                    }
                    else if ((j==length-i-2)|| (j == length - i - 3))
                    {
                        Console.Write("/");
                    }
                    
                    else
                    {
                        Console.Write("_");

                    }

                }
                Console.WriteLine();
            }

        }
    }
}
