using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {


            string month = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            if (month=="May"||month== "October")
            {
                if (days<=7)
                {
                    double priceApartament = 65 * (double)days;
                    double priceStudio = 50 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
                else if (days>7&&days<=14)
                {
                    double priceApartament = 65  * (double)days; ;
                    double priceStudio = 50 * 0.95 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
                else if (days>14)
                {
                    double priceApartament = 65 * 0.9 * (double)days;
                    double priceStudio = 50 * 0.7 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
            }else if (month== "June"||month== "September")
            {
                if (days <= 7)
                {
                    double priceApartament = 68.70 * (double)days;
                    double priceStudio = 75.20 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
                else if (days > 7 && days <= 14)
                {
                    double priceApartament = 68.70 * (double)days;
                    double priceStudio = 75.20 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
                else if (days > 14)
                {
                    double priceApartament = 68.70 * 0.9 * (double)days;
                    double priceStudio = 75.20 * 0.8 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
            }else if (month == "July" || month == "August")
            {
                if (days <= 7)
                {
                    double priceApartament = 77 * (double)days;
                    double priceStudio = 76 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
                else if (days > 7 && days <= 14)
                {
                    double priceApartament = 77 * (double)days;
                    double priceStudio = 76 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
                else if (days > 14)
                {
                    double priceApartament = 77 * 0.9 *(double)days;
                    double priceStudio = 76 * (double)days;

                    Console.WriteLine("Apartment: {0:F2} lv.", priceApartament);
                    Console.WriteLine("Studio: {0:F2} lv.", priceStudio);
                }
            }
        }
    }
}
