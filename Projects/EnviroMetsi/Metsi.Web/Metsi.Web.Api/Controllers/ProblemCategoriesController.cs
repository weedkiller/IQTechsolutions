using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Grouping.Base.Models;
using Grouping.Core.Context.Services;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;
using Troubleshooting.Base.Models.ApiModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProblemCategoriesController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private CategoryContext<Problem> _service;

        public ProblemCategoriesController(CategoryContext<Problem> service, IApplicationConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet("GetList")]
        public async Task<IEnumerable<CategoryModel>> GetList(string parentId)
        {
            IQueryable<Category<Problem>> list = _service.GetAllCategories(parentId);

            var model = new List<CategoryModel>();
            foreach (var item in list)
            {
                model.Add(new CategoryModel()
                {
                    Id = item.Id,
                    ImageUrl = item.GetPath(_configuration.BaseImageUrl, ImageType.Cover, "/images/placeholders/NoImageAvailable.jpg"),
                    Name = item.Name,
                    Description = item.Description.HtmlToPlainText(),
                    ChildCategoryCount = item.SubCategories.Count,
                    EntityCategoryCount = item.EntityCollection.Count
                });
            }

            return model;
        }
        
        /// <summary>
        /// Gets all parent categories from the database
        /// GET: api/v1/problemcategories
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="size">The page size</param>
        /// <param name="sort">The sorting order of the results</param>
        /// <returns>A <see cref="PagedResult{T}"/>of all parent categories</returns>
        [HttpGet("GetPaged")]
        public async Task<PagedResult<CategoryModel>> GetPaged(string parentId = null, int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Category<Problem>> list = _service.GetAllCategories(parentId);

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Name);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Name);
            }

            var newlist = new List<CategoryModel>();
            foreach (var item in list)
            {
                newlist.Add(new CategoryModel()
                {
                    Id = item.Id,
                    ImageUrl = item.GetPath(_configuration.BaseImageUrl, ImageType.Cover, "/images/placeholders/NoImageAvailable.jpg"),
                    Name = item.Name,
                    Description = item.Description.HtmlToPlainText(),
                    ChildCategoryCount = item.SubCategories.Count,
                    EntityCategoryCount = item.EntityCollection.Count
                });
            }

            var model = newlist.GetPaged<CategoryModel>(pageNumber, pageSize);
            model.SortOrder = (int) sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<CategoryModel> Get(string id)
        {
            var item = await _service.GetAsync(id);

            return new CategoryModel()
            {
                Id = item.Id,
                ImageUrl = item.GetPath(_configuration.BaseImageUrl, ImageType.Cover, "/images/placeholders/NoImageAvailable.jpg"),
                Name = item.Name,
                Description = item.Description.HtmlToPlainText(),
                ChildCategoryCount = item.SubCategories.Count,
                EntityCategoryCount = item.EntityCollection.Count
            };
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet, Route("subcategories")]
        public async Task<PagedResult<Category<Problem>>> GetSubCategories([FromQuery] string parentId, [FromQuery] int? page = null, [FromQuery] int? size = null, [FromQuery] int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Category<Problem>> list = _service.GetAllCategories(parentId);

            var model = list.GetPaged<Category<Problem>>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("categoryproblems")]
        public async Task<PagedResult<ProblemResultModel>> GetCategoryProblems([FromQuery]string categoryId, [FromQuery] int? page = null, [FromQuery] int? size = null, [FromQuery] int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            var list = _service.GetAllCategoryEntities(categoryId);

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Heading);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Heading);
            }

            var newList = new List<ProblemResultModel>();
            foreach (var item in list)
            {
                newList.Add(new ProblemResultModel()
                {
                    Id = item.Id,
                    Heading = item.Heading,
                    Description = item.Description.HtmlToPlainText(),
                    Tags = item.Keywords,
                    CausesCount = item.Causes.Count
                });
            }

            var model = newList.GetPaged<ProblemResultModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // POST api/<ProblemCategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProblemCategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProblemCategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
