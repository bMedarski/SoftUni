using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Drawing_tool
{
    class Program
    {
        static void Main(string[] args)
        {
            var vigure = Console.ReadLine();
            var sizes = int.Parse(Console.ReadLine());

            if (vigure == "Square")
            {
                var figure = new Square(sizes);
                var drawer = new CorDraw(figure);
                drawer.Draw();
            }
            else
            {
                var height = int.Parse(Console.ReadLine());
                var figure = new Rectangle(sizes,height);
                var drawer = new CorDraw(figure);
                drawer.Draw();
            }
        }
    }
}
