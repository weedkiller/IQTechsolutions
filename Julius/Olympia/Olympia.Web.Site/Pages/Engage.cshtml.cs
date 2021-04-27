using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Olympia.Web.Site.Pages
{
    public class EngageModel : PageModel
    {
        private readonly ILogger <EngageModel> logger;
        private ILogger<EngageModel> _logger;

        public EngageModel(ILogger <EngageModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {

        }
    }
}