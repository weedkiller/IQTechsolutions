using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Blogging.Core.Controllers;
using Grouping.Core.Context.Services;
using Microsoft.AspNetCore.Mvc;

namespace Olympia.Web.Site.Areas.CaseStudies.Controllers
{
    [Area("CaseStudies")]
    [Route("CaseStudies/[controller]/[action]")]
    public class HomeController : CaseStudyBaseController
    {
        
        public HomeController(CaseStudyContext service, CategoryContext<CaseStudy> categoryService) : base(service, categoryService)
        {
        }
       
}

}
