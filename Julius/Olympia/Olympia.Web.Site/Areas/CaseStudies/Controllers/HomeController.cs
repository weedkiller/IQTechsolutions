using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Blogging.Core.Controllers;
using Grouping.Core.Context.Services;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;




namespace Olympia.Web.Site.Areas.CaseStudies.Controllers
{


    //private IApplicationConfiguration <Iconfiguration>();

    [Area("CaseStudies")]
    [Route("CaseStudies/[controller]/[action]")]
    public class HomeController : CaseStudyBaseController
    {
        
        public HomeController(CaseStudyContext service, CategoryContext<CaseStudy> categoryService) : base(service, categoryService)
        {
        }
    }
}
