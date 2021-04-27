using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Olympia.Web.Site.Pages
{
    public class DigitalModel : PageModel
    {
        private readonly Microsoft.Extensions.Logging.ILogger<EngageModel> logger;
        private Microsoft.Extensions.Logging.ILogger<EngageModel> _logger;

        public DigitalModel(Microsoft.Extensions.Logging.ILogger<EngageModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {

        }
    }
}