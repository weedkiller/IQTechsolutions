using Calendar.Base.Entities;
using Iqt.Base.Models;

namespace Metsi.Web.Admin.Areas.Calendar.Models
{
    public class RecurringTaskAddEditModel : AddEditModelBase<RecurringTask>
    {
        public string RouteLocationId { get; set; }
    }
}
