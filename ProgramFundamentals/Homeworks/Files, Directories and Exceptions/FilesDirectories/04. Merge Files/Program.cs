using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] one = File.ReadAllLines("input/FileOne.txt");
            string[] two = File.ReadAllLines("input/FileTwo.txt");

            for (int i = 0; i < one.Length; i++)
            {
                File.AppendAllText("output/output.txt",one[i]+Environment.NewLine+two[i]+Environment.NewLine);
            }

        }
    }
}
