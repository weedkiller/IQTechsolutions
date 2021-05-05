using Microsoft.AspNetCore.Mvc;

namespace IQTechSolutions.Web.Site.Areas.Products.Controllers
{
    /// <summary>
    /// The Features Controller
    /// </summary>
    [Area("Products")]
    [Route("Products/[controller]/[action]")]
    public class FeaturesController 
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="featureService">The features context service</param>
        /// <param name="servicesService">The service context service</param>
        public FeaturesController()
        {
        }
    }
}
