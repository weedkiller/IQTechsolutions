using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Olympia.Web.Site.Pages
{
    public class ContactModel : PageModel
    {
        private readonly Microsoft.Extensions.Logging.ILogger<ContactModel> logger;
        private Microsoft.Extensions.Logging.ILogger<ContactModel> _logger;

        public ContactModel(Microsoft.Extensions.Logging.ILogger<ContactModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {

        }
    }
}