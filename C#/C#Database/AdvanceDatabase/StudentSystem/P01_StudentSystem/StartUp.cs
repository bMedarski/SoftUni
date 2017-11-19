using System;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main()
        {
            var dbContext = new StudentSystemContext();

	        dbContext.Courses.Find(1);
        }
    }
}
