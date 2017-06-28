using System;

namespace _05.Date_Modifier
{
    public class DateModifier
    {

        public void daysBetween(string dateOne, string dateTwo)
        {
            DateTime date1 = DateTime.Parse(dateOne);
            DateTime date2 = DateTime.Parse(dateTwo);
            var result = Math.Abs((date1 - date2).TotalDays);
            Console.WriteLine(result);
        }
    }
}
