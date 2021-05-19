using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IQTechSolutions.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private BlogContext _context;

        public BlogsController(BlogContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public PagedResult<BlogPost> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<BlogPost> list = _context.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Title);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Title);
            }

            var model = list.GetPaged(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}")]
        public async Task<BlogPost> Get(string id)
        {
            var bb = await _context.GetAsync(id);
            return bb;
        }

        // POST api/<BlogsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
