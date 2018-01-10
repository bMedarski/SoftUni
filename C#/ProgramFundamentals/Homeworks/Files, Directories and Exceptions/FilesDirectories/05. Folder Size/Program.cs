using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] files = Directory.GetFiles("TestFolder");
            double sum = 0;

            foreach (var item in files)
            {
                //Console.WriteLine(item);
                FileInfo fileinfo = new FileInfo(item);
                sum += fileinfo.Length;
            }
            sum = sum / 1024 / 1024;
            File.WriteAllText("output/output.txt",sum.ToString());
        }
    }
}
