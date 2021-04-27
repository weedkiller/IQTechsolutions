using System.Linq;
using System.Threading.Tasks;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Core.Context.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CorrectiveActionsController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private readonly ProblemsContext _service;

        public CorrectiveActionsController(IApplicationConfiguration configuration, ProblemsContext service)
        {
            _configuration = configuration;
            _service = service;
        }

        // GET: api/<CorrectiveActionsController>
        [HttpGet]
        public PagedResult<CorrectiveAction> Get([FromQuery] string causeId, int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<CorrectiveAction> list = _service.GetCorrectiveActionsForCause(causeId);

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Description);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Description);
            }

            var model = list.GetPaged<CorrectiveAction>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<CorrectiveActionsController>/5
        [HttpGet("{id}")]
        public async Task<CorrectiveAction> Get(string id)
        {
            var item = await _service.GetCorrectiveActionAsync(id);
            return item;
        }

        // POST api/<CorrectiveActionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CorrectiveActionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CorrectiveActionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
