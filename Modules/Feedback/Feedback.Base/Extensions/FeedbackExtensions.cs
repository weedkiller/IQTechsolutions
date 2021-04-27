using System;

namespace Feedback.Base.Extensions
{
    public static class FeedbackExtensions
    {
        public static string GetTimeSegmentString(this DateTime time)
        {
            if (time.Day == DateTime.Now.Day && time.Year == DateTime.Now.Year)
            {
                return "Today ";
            }
            else if (time.AddDays(-1).Day == DateTime.Now.Day && time.Year == DateTime.Now.Year)
            {
                return "Yesterday ";
            }

            return time.ToLongDateString();
        }
    }
}
