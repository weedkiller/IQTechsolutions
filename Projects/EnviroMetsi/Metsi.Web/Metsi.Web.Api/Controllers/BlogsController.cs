using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.ApiModels;
using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Filing.Base.Extensions;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private BlogContext _service;

        public BlogsController(BlogContext service, IApplicationConfiguration configuration)
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
        public async Task<PagedResult<BlogPostModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<BlogPost> list = _service.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Title);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Title);
            }

            var newList = new List<BlogPostModel>();

            foreach (var item in list)
            {
                newList.Add(new BlogPostModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Description.HtmlToPlainText(),
                    Created = item.Created,
                    ImageUrl = item.GetPath(_configuration.BaseImageUrl)
                });
            }

            var model = newList.GetPaged<BlogPostModel>(pageNumber, pageSize);
            model.SortOrder = (int) sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<BlogPostModel> Get(string id)
        {
            var result = await _service.GetAsync(id);

            return new BlogPostModel()
            {
                Id = result.Id,
                Title = result.Title,
                Content = result.Description.HtmlToPlainText(),
                Created = result.Created,
                ImageUrl = result.GetPath(_configuration.BaseImageUrl)
            };
        }
    }
}
