using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Rectangle_Intersection
{
    class Program
    {
        static void Main()
        {

            var count = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var length = count[0];
            var interceptions = count[1];
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < length; i++)
            {
                var inpit = Console.ReadLine().Split(' ').ToArray();
                rectangles.Add(new Rectangle(inpit[0], int.Parse(inpit[1]), int.Parse(inpit[2]), int.Parse(inpit[3]),
                    int.Parse(inpit[4])));
            }
            for (int i = 0; i < interceptions; i++)
            {
                var ids = Console.ReadLine().Split(' ').ToArray();
                if(isIntercept(rectangles.First(x=>x.ID==ids[0]), rectangles.First(x => x.ID == ids[1])))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool isIntercept(Rectangle R1, Rectangle R2)
        {
            if ((R1.TopLeftX > R2.TopLeftX+R2.Width) || (R1.TopLeftX + R1.Width < R2.TopLeftX) || (R1.TopLeftY > R2.TopLeftY+R2.Height) ||
                (R1.TopLeftY+R1.Width < R2.TopLeftY))
                //if (One.TopLeftX + One.Width < Two.TopLeftX || Two.TopLeftX + Two.Width < One.TopLeftX ||
                //One.TopLeftY + One.Height < Two.TopLeftY || Two.TopLeftY + Two.Height < One.TopLeftY)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
