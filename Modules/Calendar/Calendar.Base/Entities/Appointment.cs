using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Calendar.Base.Enums;
using Identity.Base.Entities;
using Iqt.Base.BaseTypes;
using Iqt.Base.Enums;

namespace Calendar.Base.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Represents something that needs to be done on a specific time
    /// </summary>
    public class Appointment : EntityBase
    {
        #region Public Members

        /// <summary>
        /// The recurrence rule
        /// </summary>
        public Recurrence RecurrenceRule { get; set; } = Recurrence.None;

        /// <summary>
        /// The priority of this task
        /// </summary>
        public Priority Priority { get; set; } = Priority.Medium;

        /// <summary>
        /// The heading
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// The start time
        /// </summary>
        public TimeSpan StartTime { get; set; } = DateTime.Now.TimeOfDay;

        /// <summary>
        /// The end date
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.Date;

        /// <summary>
        /// The start time
        /// </summary>
        public TimeSpan EndTime { get; set; } = new TimeSpan(0,23,59,59);

        /// <summary>
        /// The task status
        /// </summary>
        public TaskResultStatus Status { get; set; } = TaskResultStatus.ToDo;
        public bool Completed => Status == TaskResultStatus.Completed;
        public bool Canceled => Status == TaskResultStatus.Cancelled;

        #endregion

        #region Relationships

        /// <summary>
        /// The identity of the user this task belongs to
        /// </summary>
        [DisplayName("User Id"), ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public UserInfo User { get; set; }

        #endregion

        public DateTime CalculatedStartDate
        {
            get
            {
                if (StartDate < DateTime.Now)
                {
                    var dif = (DateTime.Now - StartDate).TotalDays;
                    if (RecurrenceRule == Recurrence.Daily)
                    {
                        return StartDate.AddDays(dif + 1);
                    }

                    if (RecurrenceRule == Recurrence.Weekly)
                    {
                        var extraAdd = 0;
                        if (StartDate.DayOfWeek > DateTime.Now.DayOfWeek)
                        {
                            extraAdd = 7 - (DateTime.Now.DayOfWeek - StartDate.DayOfWeek);
                        }
                        else
                        {
                            extraAdd = StartDate.DayOfWeek - DateTime.Now.DayOfWeek;
                        }
                        return StartDate.AddDays(dif + extraAdd);
                    }
                    if (RecurrenceRule == Recurrence.Monthly)
                    {
                        var monthsToAdd = 0;
                        if (StartDate.Month < DateTime.Now.Month)
                        {
                            monthsToAdd = DateTime.Now.Month - StartDate.Month;
                        }

                        if (StartDate.AddMonths(monthsToAdd) < DateTime.Now)
                        {
                            monthsToAdd = monthsToAdd + 1;
                        }
                        return StartDate.AddMonths(monthsToAdd);
                    }
                    if (RecurrenceRule == Recurrence.Yearly)
                    {
                        var yearsToAdd = 0;
                        if (StartDate.Year < DateTime.Now.Year)
                        {
                            yearsToAdd = DateTime.Now.Year - StartDate.Year;
                        }

                        if (StartDate.AddMonths(yearsToAdd) < DateTime.Now)
                        {
                            yearsToAdd = yearsToAdd + 1;
                        }
                        return StartDate.AddYears(yearsToAdd);
                    }
                }

                return StartDate;
            }
        }
    }

    
}
