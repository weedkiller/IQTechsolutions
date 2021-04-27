using Iqt.Base.Models;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Models
{
    public class CauseAddEditViewModel : AddEditModelBase<Cause>
    {
        public string ReturnUrl { get; set; }
        public Problem Problem { get; set; }
    }
}
