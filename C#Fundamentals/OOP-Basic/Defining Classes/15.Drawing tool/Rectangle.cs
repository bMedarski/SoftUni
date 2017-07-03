using System;
using System.Text;

namespace _15.Drawing_tool
{
    public class Rectangle : Shape
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    sb.AppendLine($"|{new string('-', width)}|");
                    continue;
                }

                sb.AppendLine($"|{new string(' ', width)}|");
            }

            return sb.ToString();
        }
        public override void Draw()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
