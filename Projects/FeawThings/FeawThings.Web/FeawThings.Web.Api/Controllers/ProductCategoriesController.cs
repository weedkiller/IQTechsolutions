using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Grouping.Base.Models;
using Grouping.Core.Context.Services;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Products.Base.Api.Services;
using Products.Base.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeawThings.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly CategoryContext<Product> _service;
        private readonly IApplicationConfiguration _configuration;

        public ProductCategoriesController(CategoryContext<Product> service, IApplicationConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        // GET: api/v1/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> Get(string parentId, int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            var result = _service.GetAllCategories(parentId);

            var list = new List<CategoryModel>();

            foreach (var item in result)
            {
                list.Add(new CategoryModel(item.Id,
                    item.GetPath(_configuration.BaseImageUrl, ImageType.Cover,
                        "/images/placeholders/NoImageAvailable.jpg"), item.Name, item.Description,
                    item.SubCategories.Count, item.EntityCollection.Count));
            }

            return list;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<CategoryModel> Get(string id)
        {
            var result = await _service.GetAsync(id);
            return new CategoryModel(result.Id,
                result.GetPath(_configuration.BaseImageUrl, ImageType.Cover,
                    "/images/placeholders/NoImageAvailable.jpg"), result.Name, result.Description,
                result.SubCategories.Count, result.EntityCollection.Count);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
