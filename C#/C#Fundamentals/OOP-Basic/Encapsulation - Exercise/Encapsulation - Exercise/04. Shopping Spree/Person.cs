using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;

            }
        }
        public decimal Money
        {
            get { return this.money; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;

            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get { return this.bagOfProducts.AsReadOnly(); }
        }

        public void AddProduct(Product pr)
        {

            if (this.Money >= pr.Cost)
            {
                this.Money -= pr.Cost;
                this.bagOfProducts.Add(pr);
                Console.WriteLine($"{this.Name} bought {pr.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {pr.Name}");
            }
        }
    }
}
