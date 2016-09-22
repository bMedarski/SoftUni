using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int countDoctors = 7;
            long countExamine = 0;
            long countUnExamine = 0;
            long sumExamine = 0;
            long sumUnexamine = 0;
            long examine3 = 0;
            long unExamine3 = 0;


            for (int i = 1; i<=n; i++)
            { 
    
                if (i%3==0)
                {
                    if (sumExamine < sumUnexamine)
                    {
                        countDoctors++;
                        examine3 = 0;
                        unExamine3 = 0;
                    }
                    else
                    {
                        //countDoctors = 7;
                        examine3 = 0;
                        unExamine3 = 0;
                    }
 
                }
                int pationts = int.Parse(Console.ReadLine());

                if (countDoctors >= pationts)
                {
                    countExamine = pationts;
                    countUnExamine = 0;
                }
                else
                {
                    countUnExamine = pationts - countDoctors;
                    countExamine = countDoctors;
                }
                examine3 += countExamine;
                unExamine3 += countUnExamine;
                sumExamine += countExamine;
                sumUnexamine += countUnExamine;
                countUnExamine = 0;
                countExamine = 0;

                //Console.WriteLine("examine {0} at day {1}", sumExamine, i);

            }
            Console.WriteLine("Treated patients: {0}.", sumExamine);
            Console.WriteLine("Untreated patients: {0}.", sumUnexamine);

        }
    }
}
