using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine().ToCharArray();

            foreach (var VARIABLE in input)
            {
                Console.Write("\\u");
                if ((int) VARIABLE > 99)
                {
                    //Console.Write((int) VARIABLE);
                }
                else
                {
                    //Console.Write("0");                   
                    
                    //Console.Write((int)VARIABLE);
                }
                //Console.WriteLine();
                Console.Write(String.Format("{0:x4}", (int)VARIABLE));
            }
        }
    }
}
