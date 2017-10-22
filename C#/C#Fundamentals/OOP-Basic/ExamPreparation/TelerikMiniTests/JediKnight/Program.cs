using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {


            var padawans = new Queue<string>();
            var knights = new Queue<string>();
            var masters = new Queue<string>();


            var linesOfInput = int.Parse(Console.ReadLine());
            
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            //Console.Write(string.Join(",",input));
                foreach (var item in input)
                {
                    var type = item[0];

                    if (type == 'p'||type=='P')
                    {
                        padawans.Enqueue(item);
                    }
                    else if (type == 'k' || type == 'K')
                    {
                        knights.Enqueue(item);
                    }
                    else if (type == 'm' || type == 'M')
                    {
                        masters.Enqueue(item);
                    }
                }
                Console.Write(string.Join(" ",masters));
                Console.Write(" ");
                Console.Write(string.Join(" ", knights));
                Console.Write(" ");
                Console.Write(string.Join(" ", padawans));
            //Console.WriteLine(
            //$"{string.Join(" ", masters)} {string.Join(" ", knights)} {string.Join(" ", padawans)}");
        }
    }
}
