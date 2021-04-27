using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grouping.Api.Models;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Filing.Enums;
using Iqt.Filing.Extensions;
using Iqt.Grouping.Data;
using Iqt.Grouping.Entities;
using Iqt.Troubleshooting.Entities;
using Microsoft.AspNetCore.Mvc;

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



        /// <summary>
        /// Gets all parent categories from the database
        /// GET: api/v1/problemcategories
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="size">The page size</param>
        /// <param name="sort">The sorting order of the results</param>
        /// <returns>A <see cref="PagedResult{T}"/>of all parent categories</returns>
        [HttpGet]
        public async Task<PagedResult<CategoryResultModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Category<Problem>> list = _service.GetAllParentCategories();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Name);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Name);
            }

            List<CategoryResultModel> resultList = new List<CategoryResultModel>();
            foreach (var item in list)
            {
                resultList.Add(new CategoryResultModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description.HtmlToPlainText().TruncateLongString(100).Replace("\r\n",""),
                    ImageUrl = item.GetImagePath(ImageType.Cover, null, _configuration.BaseImageUrl),
                    ParentId = item.ParentCategoryId,
                    DepartmentId = item.DepartmentId,
                    EntityCount = _service.GetEntityCount(item.Id),
                    ChildCount = _service.GetSubCategoryCount(item.Id)
                });
            }

            var model = resultList.GetPaged<CategoryResultModel>(pageNumber, pageSize);
            model.SortOrder = (int) sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<CategoryResultModel> Get(string id)
        {
            var result = await _service.GetAsync(id);

            var model =  new CategoryResultModel()
            {
                Id = id,
                Name = result.Name,
                Description = result.Description.HtmlToPlainText().TruncateLongString(100).Replace("\r\n", ""),
                ImageUrl = result.GetImagePath(ImageType.Cover, null, _configuration.BaseImageUrl),
                ParentId = result.ParentCategoryId,
                DepartmentId = result.DepartmentId,
                EntityCount = result.EntityCollection.Count,
                ChildCount = result.SubCategories.Count
            };
            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet, Route("subcategories")]
        public async Task<PagedResult<CategoryResultModel>> GetSubCategories([FromQuery] string parentId, [FromQuery] int? page = null, [FromQuery] int? size = null, [FromQuery] int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Category<Problem>> list = _service.GetAllChildCategories(parentId);

            List<CategoryResultModel> resultList = new List<CategoryResultModel>();
            foreach (var item in list)
            {
                resultList.Add(new CategoryResultModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description.HtmlToPlainText().TruncateLongString(100).Replace("\r\n", ""),
                    ImageUrl = item.GetImagePath(ImageType.Cover, null, _configuration.BaseImageUrl),
                    ParentId = item.ParentCategoryId,
                    DepartmentId = item.DepartmentId,
                    EntityCount = item.EntityCollection.Count,
                    ChildCount = item.SubCategories.Count
                });
            }

            var model = resultList.GetPaged<CategoryResultModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("categoryproblems")]
        public async Task<PagedResult<ProblemResultModel>> GetCategoryProblems([FromQuery]string id, int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            var list = _service.GetAllCategoryEntities(id);

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
                    ProblemContent = item.Description
                });
            }

            var model = resultList.GetPaged<ProblemResultModel>(pageNumber, pageSize);
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
