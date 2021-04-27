using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Api.Models;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Troubleshooting.Data;
using Iqt.Troubleshooting.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private ProblemsContext _service;

        public ProblemsController(IApplicationConfiguration configuration, ProblemsContext service)
        {
            _configuration = configuration;
            _service = service;
        }


        // GET: api/<ProblemsController>
        [HttpGet]
        public IEnumerable<string> Get(int? page = null, int? size = null, int? sort = null)
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/<ProblemsController>
        [HttpGet, Route("categoryProblems")]
        public PagedResult<ProblemResultModel> GetCategoryProblems([FromQuery]string categoryId, [FromQuery] int? page = null, [FromQuery] int? size = null, [FromQuery] int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Problem> list = _service.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Heading);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Heading);
            }

            List<ProblemResultModel> resultList = new List<ProblemResultModel>();
            foreach (var item in list)
            {
                resultList.Add(new ProblemResultModel()
                {
                    Id = item.Id,
                    Heading = item.Heading,
                    ProblemContent = item.Description,
                    CausesCount = item.Causes.Count,
                    CorrectiveActionsCount = item.Causes.Sum(c => c.CorrectiveActions.Count)
                });
            }

            var model = resultList.GetPaged<ProblemResultModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<ProblemsController>/5
        [HttpGet("{id}")]
        public async Task<ProblemResultModel> Get(string id)
        {
            var entity = await _service.GetAsync(id);
            return new ProblemResultModel()
            {
                Id = entity.Id,
                Heading = entity.Heading,
                ProblemContent = entity.Description,
                CausesCount = entity.Causes.Count,
                CorrectiveActionsCount = entity.Causes.Sum(c => c.CorrectiveActions.Count)
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
