using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Class_Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Height = height;
            this.Width = width;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    //throw new ArgumentOutOfRangeException("Length cannot be zero or negative.");
                }
                else
                {
                   this.length = value; 
                }
                
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    //throw new ArgumentOutOfRangeException("Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
                
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    //throw new ArgumentOutOfRangeException("Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
                
            }
        }

        public double Surface()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return this.Length * this.Width * 2 + this.Height * this.Length * 2 + this.Width * this.Height * 2;
        }

        public double LateralSurface()
        {
            //Lateral Surface Area = 2lh + 2wh
            return this.Length * this.Height * 2 + this.Width * this.Height * 2;
        }

        public double Volume()
        {
            return this.Height * this.Length * this.Width;
        }
    }
}
