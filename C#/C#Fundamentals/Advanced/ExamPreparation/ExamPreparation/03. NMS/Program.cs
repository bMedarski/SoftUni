using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NMS
{
    class Program
    {
        static void Main(string[] args)
        {

            var msg = new StringBuilder();

            while (true)
            {
                var input = Console.ReadLine();
                if (input== "---NMS SEND---")
                {
                    break;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    msg.Append(input[i]);                    
                }                
            }
            var delimeter = Console.ReadLine();

            var text = msg.ToString();
            var output = new StringBuilder();
            output.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                var current = (int) char.Parse(text[i].ToString().ToLower());
                var before = (int) char.Parse(text[i - 1].ToString().ToLower());
                //if ((int)char.Parse(text[i].ToString().ToLower()) < (int)char.Parse(text[i - 1].ToString().ToLower()))
                //{
                //    //Console.WriteLine((int)char.Parse(msg[i].ToString().ToLower()));
                //    //Console.WriteLine((int)char.Parse(msg[i-1].ToString().ToLower()));
                //    //foreach (var ch in delimeter)
                //    //{
                //    //    msg.Insert(i, ch);
                //    //    Console.WriteLine("***");
                //    //}
                //    msg.Insert(i, delimeter);

                //}
                if (current < before)
                {
                    output.Append(delimeter);
                    output.Append(text[i]);
                }
                else
                {
                    output.Append(text[i]);

                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
