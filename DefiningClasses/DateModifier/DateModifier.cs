using System;

namespace DateModifier
{
    public class DateModifier
    {
        public DateModifier(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public void GetAllDays(DateModifier firstDate, DateModifier secondDate)
        {
            DateTime first = new DateTime(firstDate.Year, firstDate.Month, firstDate.Day);
            DateTime second = new DateTime(secondDate.Year, secondDate.Month, secondDate.Day);
            Console.WriteLine(Math.Abs((first-second).TotalDays));
        }
    }
}