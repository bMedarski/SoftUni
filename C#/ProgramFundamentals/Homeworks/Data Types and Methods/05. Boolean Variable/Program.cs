using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {

            string num = Console.ReadLine();
            bool x = Convert.ToBoolean(num);
           
            if (x)
            {
                Console.WriteLine("Yes");
            }else
            {
                Console.WriteLine("No");
            }
        }
    }
}
