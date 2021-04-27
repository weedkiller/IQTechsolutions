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
    public class CausesController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private readonly ProblemsContext _service;

        public CausesController(ProblemsContext service, IApplicationConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        // GET: api/<CausesController>
        [HttpGet]
        public PagedResult<CauseResultModel> Get([FromQuery]string problemId, int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Cause> list = _service.GetProblemCausesAsync(problemId);

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Description);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Description);
            }

            List<CauseResultModel> resultList = new List<CauseResultModel>();
            foreach (var item in list)
            {
                resultList.Add(new CauseResultModel()
                {
                    Id = item.Id,
                    ParentId = item.ProblemId,
                    Content = item.Description,
                    CorrectiveActionsCount = item.CorrectiveActions.Count
                });
            }

            var model = resultList.GetPaged<CauseResultModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<CausesController>/5
        [HttpGet("{id}")]
        public async Task<CauseResultModel> Get(string id)
        {
            var item = await _service.GetCauseAsync(id);
            return new CauseResultModel()
            {
                Id = item.Id,
                ParentId = item.ProblemId,
                Content = item.Description,
                CorrectiveActionsCount = item.CorrectiveActions.Count
            };
        }

        // POST api/<CausesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CausesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CausesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
