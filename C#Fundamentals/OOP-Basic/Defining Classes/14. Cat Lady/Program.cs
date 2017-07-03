using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Cat_Lady
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfCats = new List<Cat>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                var split = input.Split(' ').ToArray();
                if (split[0]== "Cymric")
                {
                    var cat = new Cymric(split[1],double.Parse(split[2],CultureInfo.InvariantCulture));
                    listOfCats.Add(cat);
                }
                else if (split[0] == "StreetExtraordinaire")
                {
                    var cat = new StreetExtraordinaire(split[1], int.Parse(split[2]));
                    listOfCats.Add(cat);
                }
                else if (split[0] == "Siamese")
                {
                    var cat = new Siamese(split[1], int.Parse(split[2]));
                    listOfCats.Add(cat);
                }
                else
                {
                    throw new ArgumentException("Wrong type of Cat");
                }
            }
            var searchedCat = Console.ReadLine();
            Console.WriteLine(listOfCats.First(x=>x.Name==searchedCat).ToString());
        }
    }
}
