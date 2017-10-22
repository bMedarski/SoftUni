//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _09.Rectangle_Intersection
//{
//    class Program
//    {
//        static void Main()
//        {

//            var count = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//            var length = count[0];
//            var interceptions = count[1];
//            var rectangles = new List<Rectangle>();

//            for (int i = 0; i < length; i++)
//            {
//                var inpit = Console.ReadLine().Split(' ').ToArray();
//                rectangles.Add(new Rectangle(inpit[0], double.Parse(inpit[1]), double.Parse(inpit[2]), double.Parse(inpit[3]),
//                    double.Parse(inpit[4])));
//            }
//            for (int i = 0; i < interceptions; i++)
//            {
//                var ids = Console.ReadLine().Split(' ').ToArray();
//                if(isIntercept(rectangles.First(x=>x.ID==ids[0]), rectangles.First(x => x.ID == ids[1])))
//                {
//                    Console.WriteLine("true");
//                }
//                else
//                {
//                    Console.WriteLine("false");
//                }
//            }
//        }

//        static bool isIntercept(Rectangle R1, Rectangle R2)
//        {
//            if ((R1.TopLeftX > R2.TopLeftX+R2.Width) || (R1.TopLeftX + R1.Width < R2.TopLeftX) || (R1.TopLeftY > R2.TopLeftY+R2.Height) ||
//                (R1.TopLeftY+R1.Width < R2.TopLeftY))
//                //if (One.TopLeftX + One.Width < Two.TopLeftX || Two.TopLeftX + Two.Width < One.TopLeftX ||
//                //One.TopLeftY + One.Height < Two.TopLeftY || Two.TopLeftY + Two.Height < One.TopLeftY)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }
//    }
//}


using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var counts = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var rectangles = new Rectangle[counts[0]];

        for (int i = 0; i < counts[0]; i++)
        {
            var tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var id = tokens[0];
            var width = double.Parse(tokens[1]);
            var height = double.Parse(tokens[2]);
            var x = double.Parse(tokens[3]);
            var y = double.Parse(tokens[4]);

            rectangles[i] = new Rectangle(id, width, height, x, y);
        }

        for (int i = 0; i < counts[1]; i++)
        {
            var tokens = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var firstRectangle = rectangles.Where(r => r.ID == tokens[0]).First();
            var secondRectangle = rectangles.Where(r => r.ID == tokens[1]).First();

            Console.WriteLine(firstRectangle.Intersects(secondRectangle));
        }
    }
}