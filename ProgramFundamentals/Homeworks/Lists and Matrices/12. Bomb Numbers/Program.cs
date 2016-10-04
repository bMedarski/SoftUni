using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)             //80
        {
            List<int> array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] secondInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int bombNum = secondInput[0];
            int len = secondInput[1];
            int first = 0;
            int last = 0;
            //1 2 2 4 2 2 2 9  4 2
            // 1 4 4 2 8 9 1   9 3


            for (int i= 0; i<array.Count; i++)
            {
                if (array[i]==bombNum)
                {
                    if (i-len<0)
                    {
                        first = 0;
                    }
                    else
                    {
                        first = i - len;
                    }
                    if (i+len >= array.Count)
                    {
                        last = (array.Count-i)+len;
                    }else
                    {
                        last = len+1+(i-first);
                    }
                    while (last > 0)
                    {
                        array.RemoveAt(first);
                        last--;
                    }
                    
                }
                
            }
            if (array.Count==0)
            {
                Console.Write(0);
            }else
            {
                SumListNums(array);
            }
            
        }
        static void SumListNums(List<int> array)
        {

            int sum = 0;
            for (int i = 0; i<array.Count; i++)
            {
                sum += array[i];
            }
            Console.WriteLine(sum);
        }
    }
}
