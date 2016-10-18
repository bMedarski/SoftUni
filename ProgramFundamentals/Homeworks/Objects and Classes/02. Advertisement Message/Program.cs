using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] phrases = new string[6]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            string[] events = new string[6]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            string[] author = new string[8]
            {
                "Diana","Petya","Stella","Elena","Katya","Iva","Annie","Eva"
            };
            string[] city = new string[5]
            {
                "Burgas","Sofia","Plovdiv","Varna","Ruse"
            };
            Random item = new Random();
           // index = x.Next(0, array.Count - 1);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phrases[item.Next(6)]} {events[item.Next(6)]} {author[item.Next(8)]} - {city[item.Next(5)]}");
            }



    }
    }
}
