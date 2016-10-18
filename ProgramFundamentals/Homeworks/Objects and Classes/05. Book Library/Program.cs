using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Book_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library newLibrary = new Library();
            int n = int.Parse(Console.ReadLine());
            List<Book> book = new List<Book>();
            Dictionary<string, double> finalList = new Dictionary<string, double>();
            newLibrary.Books = book;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                Book newBook = new Book();
                newBook.Author = input[1];
                newBook.Title = input[0];
                newBook.Publisher = input[2];
                newBook.ReleaseDate = DateTime.ParseExact(input[3],"dd.MM.yyyy",null);
                newBook.Isbn = input[4];
                newBook.Price = double.Parse(input[5]);               
                book.Add(newBook);
                newLibrary.Books = book;
            }
            
            foreach (var item in newLibrary.Books)
            {
                if (!finalList.ContainsKey(item.Author))
                {
                    finalList.Add(item.Author, item.Price);
                }else
                {
                    finalList[item.Author] += item.Price;
                }               
            }
            foreach (var item in finalList.OrderBy(x=>x.Key).OrderByDescending(x=>x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");

            }
           
        }
    }
    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
    }
}
