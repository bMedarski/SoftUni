using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Book_Shop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            protected set
            {
                var names = value.Trim().Split();
                if (names.Length!=2)
                {
                    throw new ArgumentException("Author not valid!");
                }
                if (char.IsDigit(names[0][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                if (char.IsDigit(names[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }               
                if (!names.Any())
                    return;

                if (Char.IsDigit(names.First()[0]))
                    throw new ArgumentException("Author not valid!");

                if (Char.IsDigit(names.Last()[0]))
                    throw new ArgumentException("Author not valid!");              
                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            protected set
            {
                if (value.Length<=3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value<1)
                {
                    throw new ArgumentException("Price not valid!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
                .Append("Title: ").AppendLine(this.Title)
                .Append("Author: ").AppendLine(this.Author)
                .Append("Price: ").Append($"{this.Price:f1}")
                .AppendLine();

            return sb.ToString();
        }

    }
}
