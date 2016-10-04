using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i<=n; i++)
            {

                int sum = 0;
                int currNumber = i;
                while (currNumber > 0)
                {
                   sum  += currNumber % 10;

                    currNumber = currNumber / 10;
                    
                }
                if (sum==11||sum==5||sum==7)
                {
                    Console.WriteLine("{0} -> True", i);
                }else
                {
                    Console.WriteLine("{0} -> False", i);
                }
                
            }
        }
    }
}
