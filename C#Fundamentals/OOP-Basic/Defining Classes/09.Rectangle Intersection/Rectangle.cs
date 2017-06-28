using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Rectangle_Intersection
{
    public class Rectangle
    {
        private string id;
        private long width;
        private long height;
        private long topLeftX;
        private long topLeftY;

        public Rectangle(string id, long width, long height, long topLX, long topLY)
        {
            this.ID = id;
            this.Width = width;
            this.Height = height;
            this.TopLeftX = topLX;
            this.TopLeftY = topLY;
        }

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public long Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public long Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        public long TopLeftX
        {
            get { return this.topLeftX; }
            set { this.topLeftX = value; }
        }
        public long TopLeftY
        {
            get { return this.topLeftY; }
            set { this.topLeftY = value; }
        }
    }
}
