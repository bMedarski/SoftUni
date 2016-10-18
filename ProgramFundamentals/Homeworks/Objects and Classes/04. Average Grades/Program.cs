using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> averageGrades = new Dictionary<string, double>();
            int n = int.Parse(Console.ReadLine());
            List<Student> studetsList = new List<Student>();
            for (int i = 0; i < n; i++)
            {               
                List<string> input = Console.ReadLine().Split().ToList();
                //Console.WriteLine(string.Join(",",input));
                List<double> grad = new List<double>();
                string name = input[0];
                input.RemoveAt(0);
                //Console.WriteLine(string.Join(",", input));
                for (int j = 0; j < input.Count; j++)
                {
                    //double num = double.Parse(input[j]);
                    //Console.WriteLine(num);
                    grad.Add(double.Parse(input[j])); 
                }
                Student student = new Student()
                {
                    name = name,
                    grades = grad
                };
                student.average = student.grades.Average();
                
                if (student.average>=5.0)
                {
                    studetsList.Add(student);
                }
                grad.Clear();         
            }
            studetsList.OrderByDescending(x=>x);
            foreach (var item in studetsList.OrderByDescending(x => x.average).OrderBy(y=>y.name))
            {
                Console.WriteLine($"{item.name} -> {item.average:F2}");
            }
        }
       
    }
    class Student
    {
        public string name { get; set; }
        public List<double> grades { get; set; } 
        public double average  { get; set; }
}
}
