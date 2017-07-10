using System.Collections.Generic;
using Exam.Contracts;

namespace Exam.Models
{
    static class Data
    {
        public static Dictionary<int,ICar> cars = new Dictionary<int, ICar>();
        public static Dictionary<int, IRace> races = new Dictionary<int, IRace>();
        public static Dictionary<int, ICar> garage = new Dictionary<int, ICar>();
    }
}
