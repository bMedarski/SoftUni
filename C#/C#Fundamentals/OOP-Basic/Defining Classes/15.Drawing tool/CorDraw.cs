
using System;
using System.Runtime.InteropServices;

namespace _15.Drawing_tool
{
    public class CorDraw
    {
        private IShape figure;

        public CorDraw(IShape figure)
        {
            this.Figure = figure;
        }

        public IShape Figure
        {
            get { return this.figure; }
            set { this.figure = value; }
        }

        public void Draw()
        {
            figure.Draw();
        }
    }
}
