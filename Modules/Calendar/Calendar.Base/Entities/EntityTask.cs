using System.ComponentModel.DataAnnotations.Schema;

namespace Calendar.Base.Entities
{
    /// <summary>
    /// Updates for projects
    /// </summary>
    public class EntityTask<T> 
    {
        [ForeignKey(nameof(Task))]
        public string TaskId { get; set; }
        public RecurringTask Task { get; set; }


        /// <summary>
        /// Gets or sets the object this update belongs to
        /// </summary>
        [ForeignKey(nameof(Entity))]
        public string EntityId { get; set; }
        public T Entity { get; set; }
    }
}
