using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Iqt.Base.BaseTypes;
using Iqt.Base.Entities;
using Iqt.Base.Enums;

namespace Calendar.Base.Entities
{
    /// <summary>
    /// A recurring task for the calendar
    /// </summary>
    public class RecurringTask : EntityBase
    {
        /// <summary>
        /// The string class of the icon
        /// </summary>
        public string IconString { get; set; }

        public Priority TaskPriority { get; set; } = Priority.Medium;

        /// <summary>
        /// The name of the Task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the task
        /// </summary>
        public string Description { get; set; }

        public bool ListedCalendarItem { get; set; }

        /// <summary>
        /// Gets or sets the estimated time it will take to complete this task
        /// </summary>
        public double EstimatedCompletionTime { get; set; } = 30;

        /// <summary>
        /// The location of the task
        /// </summary>
        public Address<RecurringTask> Address { get; set; } = new Address<RecurringTask>();

        /// <summary>
        /// The parent task of the recurring task if this is a child task
        /// </summary>
        [ForeignKey(nameof(ParentTask))]
        public string ParentTaskId { get; set; }
        public RecurringTask ParentTask { get; set; }

        /// <summary>
        /// Gets or Sets the collection of sub-tasks to be done when doing this task
        /// </summary>
        public ICollection<RecurringTask> Tasks { get; set; } = new List<RecurringTask>();

        /// <summary>
        /// Gets or Sets the collection of sub-tasks to be done when doing this task
        /// </summary>
        public ICollection<EntityTask<RouteLocation>> LocationTasks { get; set; } = new List<EntityTask<RouteLocation>>();
        

        /// <summary>
        /// Gets or Sets the collection of sub-tasks to be done when doing this task
        /// </summary>
        public ICollection<FormElement<RecurringTask>> FormElements { get; set; } = new List<FormElement<RecurringTask>>();
    }
}
