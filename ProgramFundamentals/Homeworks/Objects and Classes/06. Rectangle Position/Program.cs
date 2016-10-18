using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rectangle_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            int[] firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Rectangle firstRect = getRect(firstInput);
            Rectangle secondRect = getRect(secondInput);
            if (isInside(firstRect,secondRect))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
            

        }

        private static bool isInside(Rectangle firstRect, Rectangle secondRect)
        {
            if (firstRect.left>=secondRect.left
                &&firstRect.top>=secondRect.top
                &&(firstRect.width+firstRect.left)<=(secondRect.width+secondRect.left)
                &&(firstRect.top+firstRect.height)<=(secondRect.top+secondRect.height))
            {
                return true;
            }else
            {
                return false;
            }           
        }

        private static Rectangle getRect(int[] first)
        {
            Rectangle rect = new Rectangle();
            rect.left = first[0];
            rect.top = first[1];
            rect.width = first[2];
            rect.height = first[3];

            return rect;
        }
    }
    class Rectangle
    {
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
