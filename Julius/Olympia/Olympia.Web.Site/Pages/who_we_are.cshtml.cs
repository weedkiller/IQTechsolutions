using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Olympia.Web.Site.Pages
{
    public class who_we_areModel : PageModel
    {
        private Microsoft.Extensions.Logging.ILogger<who_we_areModel> logger;
        private Microsoft.Extensions.Logging.ILogger<who_we_areModel> _logger;

        public who_we_areModel(Microsoft.Extensions.Logging.ILogger<who_we_areModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {

        }
    }
}