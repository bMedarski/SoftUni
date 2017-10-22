using System;
using System.Collections.Generic;


namespace WeekDay
{
	public class WeeklyCalendar
	{
		private IList<WeeklyEntry> weeklySchedule;


		public WeeklyCalendar()
		{
			this.weeklySchedule = new List<WeeklyEntry>();
		}

		public void AddEntry(string weekday, string notes)
		{
			this.WeeklySchedule.Add(new WeeklyEntry(weekday,notes));
			
		}

		public IList<WeeklyEntry> WeeklySchedule
		{
			get { return this.weeklySchedule; }
		}

	}
}
