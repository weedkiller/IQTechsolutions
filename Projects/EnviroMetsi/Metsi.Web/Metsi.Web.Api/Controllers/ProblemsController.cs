using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Core.Context.Services;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Entities;
using Troubleshooting.Base.Models.ApiModels;
using Troubleshooting.Core.Context.Services;

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private ProblemsContext _context;
        private CategoryContext<Problem> _categoryContext;

        public ProblemsController(IApplicationConfiguration configuration, ProblemsContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        // GET: api/<ProblemsController>
        [HttpGet]
        public string Get(int? page = null, int? size = null, int? sort = null)
        {
            //var sortOrder = SortOrder.None;
            //var pageNumber = 1;
            //var pageSize = 12;

            //IQueryable<Problem> list = _context.GetAll();

            //if (sortOrder == SortOrder.NameAssending)
            //{
            //    list = list.OrderBy(c => c.Heading);
            //}
            //else if (sortOrder == SortOrder.NameDesending)
            //{
            //    list = list.OrderByDescending(c => c.Heading);
            //}

            //var newlist = new List<ProblemModel>();
            //foreach (var e in list)
            //{
            //    newlist.Add(new ProblemModel()
            //    {
            //        Name =  e.Heading
            //    });
            //}

            //var model = newlist.GetPaged<ProblemModel>(pageNumber, pageSize);
            //model.SortOrder = (int)sortOrder;

            

            return "";
        }
        // GET: api/<ProblemsController>
        [HttpGet, Route("categoryProblems")]
        public PagedResult<Problem> GetCategoryProblems([FromQuery]string categoryId, [FromQuery] int? page = null, [FromQuery] int? size = null, [FromQuery] int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Problem> list = _context.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Heading);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Heading);
            }

            var model = list.GetPaged<Problem>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        /// <summary>
        /// Get the autocomplete list for the problem textbox
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getProblemAutoComplete")]
        public async Task<ActionResult> GetProblemAutoComplete()
        {
           
                string term = HttpContext.Request.Query["term"].ToString();
                var problems = (from problem in _context.GetAll().Where(c => c.Description.Contains(term))
                    select new { value = problem.Description.HtmlToPlainText() }).ToList();

                return Ok(problems);

        }

        // GET api/<ProblemsController>/5
        [HttpGet("{id}")]
        public async Task<ProblemResultModel> Get(string id)
        {
            var entity = await _context.GetAsync(id);

            return new ProblemResultModel()
            {
                Id = entity.Id,
                Heading = entity.Heading,
                Description = entity.Description,
                Tags = entity.Keywords,
                CausesCount = entity.Causes.Count
            };
        }

        // POST api/<ProblemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProblemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProblemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
