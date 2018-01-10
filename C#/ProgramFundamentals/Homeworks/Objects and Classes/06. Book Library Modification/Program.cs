using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Book_Library_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            Library newLibrary = new Library();
            int n = int.Parse(Console.ReadLine());
            List<Book> book = new List<Book>();
            Dictionary<string, DateTime> finalList = new Dictionary<string, DateTime>();
            newLibrary.Books = book;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                Book newBook = new Book();
                newBook.Author = input[1];
                newBook.Title = input[0];
                newBook.Publisher = input[2];
                newBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", null);
                newBook.Isbn = input[4];
                newBook.Price = double.Parse(input[5]);
                book.Add(newBook);
                newLibrary.Books = book;
            }
            string date = Console.ReadLine();
            DateTime afterDate = DateTime.ParseExact(date,"dd.MM.yyyy",null);

            foreach (var item in newLibrary.Books)
            {
                if (item.ReleaseDate > afterDate)
                {


                    if (!finalList.ContainsKey(item.Title))
                    {
                        finalList.Add(item.Title, item.ReleaseDate);
                    }                   
                }
            }
            foreach (var item in finalList.OrderBy(x=>x.Key).OrderBy(x => x.Value))
            {
                string format = "dd.MM.yyyy";
                Console.WriteLine($"{item.Key} -> {item.Value.ToString(format)}");
                
                
                //Console.WriteLine(time.ToString(format));
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
