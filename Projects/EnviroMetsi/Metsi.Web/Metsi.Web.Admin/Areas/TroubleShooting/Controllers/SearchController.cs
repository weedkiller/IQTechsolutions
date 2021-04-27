using System;
using System.Linq;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;

namespace Metsi.Web.Site.Admin.Areas.Troubleshooting.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        /// <summary>
        /// The Applciation Db Context
        /// </summary>
        private readonly IRepositoryManager _manager;

        public SearchController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// Get the autocomplete list for the problem textbox
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getProblemAutoComplete")]
        public ActionResult GetProblemAutoComplete()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var problems = (from problem in _manager.Repository<Problem>().GetAll().Where(c => c.Description.Contains(term))
                                select new { value = problem.Description.HtmlToPlainText() }).ToList();

                return Ok(problems);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}