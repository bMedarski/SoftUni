using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGraduation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var studentsCount = int.Parse(Console.ReadLine());
            var students = new Student[studentsCount];
            for (int i = 0; i < studentsCount; i++)
            {
                var name = Console.ReadLine();
                var grades = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                students[i] = new Student(name, grades); 
                              
            }
            Array.Sort(students, (x, y) => x.name.CompareTo(y.name));
            for (int i = 0; i < studentsCount; i++)
            {
               Console.WriteLine($"{students[i].name} is graduated with {students[i].AverageSum()}");

            }

        }
    }

    public class Student
    {
        public string name;
        public double[] grades;

        public Student(string name, double[] grades)
        {
            this.name = name;
            this.grades = grades;
        }

        public double AverageSum()
        {
            double sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i];
            }
            return sum / grades.Length;
        }

    }
}
