using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {

            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            var dateMOdifier = new DateModifier();
            dateMOdifier.daysBetween(dateOne,dateTwo);
        }
    }
}
