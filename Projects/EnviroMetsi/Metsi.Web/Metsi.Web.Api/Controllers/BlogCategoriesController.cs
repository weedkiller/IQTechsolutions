using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.ApiModels;
using Blogging.Base.Entities;
using Filing.Base.Extensions;
using Grouping.Base.Entities;
using Grouping.Core.Context.Services;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Troubleshooting.Base.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private CategoryContext<BlogPost> _service;

        public BlogCategoriesController(CategoryContext<BlogPost> service, IApplicationConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }



        /// <summary>
        /// Gets all parent categories from the database
        /// GET: api/v1/problemcategories
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="size">The page size</param>
        /// <param name="sort">The sorting order of the results</param>
        /// <returns>A <see cref="PagedResult{T}"/>of all parent categories</returns>
        [HttpGet]
        public async Task<PagedResult<BlogCategoryModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Category<BlogPost>> list = _service.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Name);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Name);
            }

            var newList = new List<BlogCategoryModel>();

            foreach (var item in list)
            {
                newList.Add(new BlogCategoryModel()
                {
                    Id = item.Id,
                    ImageUrl = item.GetPath(_configuration.BaseImageUrl),
                    Name = item.Name,
                    Description = item.Description.HtmlToPlainText(),
                    CollectionCount = item.EntityCollection.Count
                });
            }

            var model = newList.GetPaged<BlogCategoryModel>(pageNumber, pageSize);
            model.SortOrder = (int) sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<BlogCategoryModel> Get(string id)
        {
            var result = await _service.GetAsync(id);
            return new BlogCategoryModel()
            {
                Id = result.Id,
                ImageUrl = result.GetPath(_configuration.BaseImageUrl),
                Name = result.Name,
                Description = result.Description.HtmlToPlainText(),
                CollectionCount = result.EntityCollection.Count
            };
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet, Route("subcategories")]
        public async Task<PagedResult<Category<BlogPost>>> GetSubCategories([FromQuery] string parentId, [FromQuery] int? page = null, [FromQuery] int? size = null, [FromQuery] int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Category<BlogPost>> list = _service.GetAllCategories(parentId);

            var model = list.GetPaged<Category<BlogPost>>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("categoryblogposts")]
        public async Task<PagedResult<BlogPost>> GetCategoryBlogPosts([FromQuery]string id, int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            var list = _service.GetAllCategoryEntities(id);

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Title);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Title);
            }

            var model = list.GetPaged<BlogPost>(pageNumber, pageSize);
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
