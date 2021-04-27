using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.ApiModels;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;

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
        [HttpGet("GetAll")]
        public IEnumerable<CauseResultModel> GetAll(string problemId)
        {
            IQueryable<Cause> problemCauses = _service.GetProblemCausesAsync(problemId);
            var model = new List<CauseResultModel>();
            foreach (var problemCause in problemCauses)
            {
                model.Add(new CauseResultModel()
                {
                    Id = problemCause.Id,
                    Description = problemCause.Description,
                    CorrectiveActionsCount = problemCause.CorrectiveActions.Count
                });
            }
            return model;
        }

        // GET: api/<CausesController>
        [HttpGet("GetPaged")]
        public PagedResult<Cause> GetPaged([FromQuery]string problemId, int? page = null, int? size = null, int? sort = null)
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
            
            var model = list.GetPaged<Cause>(pageNumber, pageSize);
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
                Description = item.Description,
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
