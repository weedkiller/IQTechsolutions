using System;
using System.Collections.Generic;
using System.Globalization;

namespace Iqt.Base.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets abbreviated text for the month name
        /// </summary>
        /// <param name="monthName">The month name that must be abbreviated</param>
        /// <returns>The abbreviated month</returns>
        public static string GetAbbreviatedMonth(this string monthName)
        {
            DateTime month;
            return DateTime.TryParseExact(
                monthName,
                "MMMM",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out month)
                ? month.ToString("MMM")
                : null;
        }
        /// <summary>
        /// Gets abbreviated text for the month number
        /// </summary>
        /// <param name="monthNr">The number of the month that should be abbreviate</param>
        /// <returns>The abbreviated month</returns>
        public static string GetAbbreviatedMonth(this int monthNr)
        {
            DateTime month;
            return DateTime.TryParseExact(
                monthNr.GetMonthFromMonthNr(),
                "MMMM",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out month)
                ? month.ToString("MMM")
                : null;
        }

        /// <summary>
        /// Gets the month name from the month number
        /// </summary>
        /// <param name="monthNr">The month number</param>
        /// <returns>The month name</returns>
        public static string GetMonthFromMonthNr(this int monthNr)
        {
            DateTimeFormatInfo mfi = new DateTimeFormatInfo();
            return mfi.GetMonthName(monthNr);
        }

        /// <summary>
        /// Gets the year and the month name from a specific <see cref="DateTime"/>
        /// </summary>
        /// <param name="date">The specific date</param>
        /// <returns>The month and the year as string</returns>
        public static string GetMonthAndYearFromDate(this DateTime date)
        {
            DateTimeFormatInfo mfi = new DateTimeFormatInfo();
            return $"{mfi.GetMonthName(date.Month)} {date.Year}";
        }

        /// <summary>
        /// Gets a persons age from his/her identity number
        /// </summary>
        /// <param name="idNumber">The identity number</param>
        /// <returns>The age as a <see cref="int"/></returns>
        public static int GetAge(this string idNumber)
        {
            idNumber = idNumber.Trim().Replace(" ", "");
            int year = Convert.ToInt32(idNumber.Substring(0, 2));
            int month = Convert.ToInt32(idNumber.Substring(2, 2));
            int day = Convert.ToInt32(idNumber.Substring(4, 2));

            DateTime dob = new DateTime(year, month, day);
            return DateTime.Now.Year - (dob.Year + 1900);
        }

        /// <summary>
        /// Gets a persons age from his/her date of birth as <see cref="DateTime"/>
        /// </summary>
        /// <param name="dob">The date of birth</param>
        /// <returns>The age as a <see cref="int"/></returns>
        public static int GetAge(this DateTime dob)
        {
            return DateTime.Now.Year - (dob.Year + 1900);
        }

        /// <summary>
        /// Gets a list of dates between two specific <see cref="DateTime"/>
        /// </summary>
        /// <param name="startDate">The start date of the list</param>
        /// <param name="endDate">The end date of the list</param>
        /// <returns>A list of dates</returns>
        public static List<DateTime> GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            List<DateTime> allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);
            return allDates;

        }

        /// <summary>
        /// Gets the starting date of a week
        /// </summary>
        /// <param name="input">The date that should be queried</param>
        /// <returns>A <see cref="DateTime"/> of the start of the week</returns>
        public static DateTime GetStartOfWeek(DateTime input)
        {
            // Using +6 here leaves Monday as 0, Tuesday as 1 etc.
            int dayOfWeek = (((int)input.DayOfWeek) + 6) % 7;
            return input.Date.AddDays(-dayOfWeek);
        }

        /// <summary>
        /// Gets the number of weeks between two <see cref="DateTime"/>
        /// </summary>
        /// <param name="start">The start date of the list</param>
        /// <param name="end">The end date of the list</param>
        /// <returns>The number of weeks as <see cref="int"/></returns>
        public static int GetWeeks(DateTime start, DateTime end)
        {
            start = GetStartOfWeek(start);
            end = GetStartOfWeek(end);
            int days = (int)(end - start).TotalDays;
            return (days / 7) + 1; // Adding 1 to be inclusive
        }

        public static string DisplayDateTimeIntervalString(this DateTime date)
        {
            if (date.Date == DateTime.Now.Date)
            {
                var val = DateTime.Now.TimeOfDay - date.TimeOfDay;

                if (val.Hours <= 1)
                {
                    return val.Minutes + " minutes ago";
                }

                return val.Hours + " hours ago";
            }

            if (date.Month == DateTime.Now.Month)
            {
                if (date.Date.AddDays(1) < DateTime.Now.Date)
                {
                    return "Yesterday";
                    
                }

                return (DateTime.Now.Date - date.Date).TotalDays + " days ago";
            }

            return date.ToLongDateString();
        }
    }
}
