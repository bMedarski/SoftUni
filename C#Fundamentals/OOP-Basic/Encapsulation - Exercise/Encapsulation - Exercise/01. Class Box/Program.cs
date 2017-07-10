using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.Class_Box
{
    class Program
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());


            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var box = new Box(length,width,height);

            if (box.Height!=0&&box.Length!=0&&box.Width!=0)
            {
               Console.WriteLine($"Surface Area - {box.Surface():F2}");
               Console.WriteLine($"Lateral Surface Area - {box.LateralSurface():F2}");
               Console.WriteLine($"Volume - {box.Volume():F2}"); 
            }
            


        }
    }
}
