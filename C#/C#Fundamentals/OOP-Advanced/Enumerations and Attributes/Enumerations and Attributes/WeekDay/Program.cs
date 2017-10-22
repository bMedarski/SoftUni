using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekDay
{
	class Program
	{
		static void Main()
		{
			WeeklyCalendar calendar = new WeeklyCalendar();
			calendar.AddEntry("Monday", "Internal meeting");
			calendar.AddEntry("Tuesday", "Create presentation");
			calendar.AddEntry("Tuesday", "Create lab and exercise");
			calendar.AddEntry("Thursday", "Enum Lecture");
			calendar.AddEntry("Monday", "Second internal meeting");

			var ordered = calendar.WeeklySchedule.OrderBy(n => n).ToList();
			foreach (var weeklyEntry in ordered)
			{
				Console.WriteLine(weeklyEntry);
			}

		}
	}
}
