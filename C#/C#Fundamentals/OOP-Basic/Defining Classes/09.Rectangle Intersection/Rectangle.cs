//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _09.Rectangle_Intersection
//{
//    public class Rectangle
//    {
//        private string id;
//        private double width;
//        private double height;
//        private double topLeftX;
//        private double topLeftY;

//        public Rectangle(string id, double width, double height, double topLX, double topLY)
//        {
//            this.ID = id;
//            this.Width = width;
//            this.Height = height;
//            this.TopLeftX = topLX;
//            this.TopLeftY = topLY;
//        }

//        public string ID
//        {
//            get { return this.id; }
//            set { this.id = value; }
//        }
//        public double Width
//        {
//            get { return this.width; }
//            set { this.width = value; }
//        }
//        public double Height
//        {
//            get { return this.height; }
//            set { this.height = value; }
//        }
//        public double TopLeftX
//        {
//            get { return this.topLeftX; }
//            set { this.topLeftX = value; }
//        }
//        public double TopLeftY
//        {
//            get { return this.topLeftY; }
//            set { this.topLeftY = value; }
//        }
//    }
//}

class Rectangle
{
    public string ID { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.ID = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public string Intersects(Rectangle rectangle)
    {
        if ((rectangle.Y >= this.Y && rectangle.Y - rectangle.Height <= this.Y && rectangle.X <= this.X && rectangle.X + rectangle.Width >= this.X) ||
            (rectangle.Y >= this.Y && rectangle.Y - rectangle.Height <= this.Y && rectangle.X >= this.X && rectangle.X <= this.X + this.Width) ||
            (rectangle.Y <= this.Y && rectangle.Y >= this.Y - this.Height && rectangle.X <= this.X && rectangle.X + rectangle.Width >= this.X) ||
            (rectangle.Y <= this.Y && rectangle.Y >= this.Y - this.Height && rectangle.X >= this.X && rectangle.X <= this.X + this.Width))
        {
            return "true";
        }

        return "false";
    }

}