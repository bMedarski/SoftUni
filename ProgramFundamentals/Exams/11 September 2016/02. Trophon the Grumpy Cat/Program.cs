using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.Trophon_the_Grumpy_Cat
{
    class Program
    {
        static void Main(string[] args)
        {

            BigInteger[] input = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            int index = int.Parse(Console.ReadLine());

            string priceRating = Console.ReadLine();
            string typeOfPrice = Console.ReadLine();

            BigInteger startingIndex = input[index];
            int leftLength = index;
            int rightLength = input.Length - index;
            BigInteger sumLeft = 0,
                sumRight = 0;

            for (int i = 0; i<leftLength; i++)
            {
                if (priceRating=="cheap")
                {
                    if (typeOfPrice=="positive")
                    {
                        if ((input[i] > 0) && (input[i] < startingIndex))
                        {
                            sumLeft += input[i];
                        }
                    }else if(typeOfPrice == "negative")
                    {
                        if ((input[i] < 0) && (input[i] < startingIndex))
                        {
                            sumLeft += input[i];
                        }
                    }
                    else
                    {
                        if ((input[i] < startingIndex))
                        {
                            sumLeft += input[i];
                        }
                    }
                }else if (priceRating == "expensive")
                {
                    if (typeOfPrice == "positive")
                    {
                        if ((input[i] > 0) && (input[i] >= startingIndex))
                        {
                            sumLeft += input[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if ((input[i] < 0) && (input[i] >= startingIndex))
                        {
                            sumLeft += input[i];
                        }
                    }
                    else
                    {
                        if ((input[i] >= startingIndex))
                        {
                            sumLeft += input[i];
                        }
                    }
                }
            }
            for (int i = index+1; i < input.Length; i++)
            {
                if (priceRating == "cheap")
                {
                    if (typeOfPrice == "positive")
                    {
                        if ((input[i] > 0) && (input[i] < startingIndex))
                        {
                            sumRight += input[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if ((input[i] < 0) && (input[i] < startingIndex))
                        {
                            sumRight += input[i];
                        }
                    }
                    else
                    {
                        if ((input[i] < startingIndex))
                        {
                            sumRight += input[i];
                        }
                    }
                }
                else if (priceRating == "expensive")
                {
                    if (typeOfPrice == "positive")
                    {
                        if ((input[i] > 0) && (input[i] >= startingIndex))
                        {
                            sumRight += input[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if ((input[i] < 0) && (input[i] >= startingIndex))
                        {
                            sumRight += input[i];
                        }
                    }
                    else
                    {
                        if ((input[i] >= startingIndex))
                        {
                            sumRight += input[i];
                        }
                    }
                }
            }
            if (sumLeft>=sumRight)
            {
                Console.WriteLine("Left - {0}",sumLeft);
            }
            else
            {
                Console.WriteLine("Right - {0}", sumRight);
            }

        }
    }
}
