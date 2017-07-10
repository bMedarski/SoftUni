using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            var shoppers = new List<Person>();
            var products = new List<Product>();
            var persons = Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var person in persons)
            {
                var split = person.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    var p = new Person(split[0], decimal.Parse(split[1], CultureInfo.InvariantCulture));
                    shoppers.Add(p);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);                    
                }               
            }
            var prods = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var pr in prods)
            {
                var split = pr.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    var p = new Product(split[0], decimal.Parse(split[1],CultureInfo.InvariantCulture));
                    products.Add(p);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                   
                }              
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }
                var splitInput = input.Split(' ').ToArray();

                if (shoppers.Count>0&&products.Count>0)
                {

                        var product = products.Where(x => x.Name == splitInput[1]).First();
                        shoppers.Where(x=>x.Name==splitInput[0]).First().AddProduct(product);                   
                }
                    

            }
            foreach (var shopper in shoppers)
            {
                if (shopper.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{shopper.Name} - Nothing bought");
                }
                else
                {
                    //Console.WriteLine(shopper.BagOfProducts.Count);
                    Console.WriteLine($"{shopper.Name} - {string.Join(", ",shopper.BagOfProducts.Select(x=>x.Name))}");
                }
            }
        }
    }
}
