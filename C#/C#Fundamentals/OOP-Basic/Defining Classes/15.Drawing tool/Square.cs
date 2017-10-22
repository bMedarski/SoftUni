using System;
using System.Text;

namespace _15.Drawing_tool
{
    public class Square : Shape
    {
        private int width;

        public Square(int width)
        {
            this.Width = width;
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                if (i == 0 || i == width - 1)
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
