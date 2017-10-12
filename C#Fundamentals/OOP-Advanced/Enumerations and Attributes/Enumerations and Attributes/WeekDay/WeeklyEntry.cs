using System;

namespace WeekDay
{
	public class WeeklyEntry:IComparable<WeeklyEntry>
	{
		private Weekdays weekday;
		private string notes;

		public WeeklyEntry(string weekday, string notes)
		{
			Enum.TryParse(weekday, out this.weekday);
			this.Notes = notes;
		}

		public Weekdays Weekday
		{
			get => this.weekday;
		}

		public string Notes
		{
			get => this.notes;
			set => this.notes = value;
		}

		public int CompareTo(WeeklyEntry other)
		{
			if (this.CompareTo(other)==0)
			{
				return this.Notes.CompareTo(other.Notes);
			}
			return this.CompareTo(other);
		}

		public override string ToString()
		{
			return $"{this.Weekday} = {this.Notes}";
		}
	}
}
