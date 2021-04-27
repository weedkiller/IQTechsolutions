using Iqt.Base.Models;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Models
{
    public class CorrectiveActionAddEditViewModel : AddEditModelBase<CorrectiveAction>
    {
        public string ReturnUrl { get; set; }
        
        public Cause Cause { get; set; }

        public Problem Problem { get; set; }
    }
}
