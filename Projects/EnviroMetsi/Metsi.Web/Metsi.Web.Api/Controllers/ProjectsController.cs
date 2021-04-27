using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogging.Base.ApiModels;
using Blogging.Base.Entities;
using Blogging.Core.Context.Services;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Mvc;
using Projects.Base.ApiModels;
using Projects.Base.Entities;
using Projects.Core.Context.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private ProjectsContext _service;

        public ProjectsController(ProjectsContext service, IApplicationConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        
        /// <summary>
        /// Gets all <see cref="Project"/> from the database
        /// GET: api/v1/problemcategories
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="size">The page size</param>
        /// <param name="sort">The sorting order of the results</param>
        /// <returns>A <see cref="PagedResult{T}"/>of all parent categories</returns>
        [HttpGet]
        public async Task<PagedResult<ProjectModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Project> list = _service.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.ProjectName);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.ProjectName);
            }

            var newList = new List<ProjectModel>();

            foreach (var item in list)
            {
                newList.Add(new ProjectModel()
                {
                    Id = item.Id,
                    StartDate = item.StartDate.Value,
                    EndDate = item.EndDate.Value,
                    ProjectName = item.ProjectName,
                    CoverImageUrl = item.GetPath(_configuration.BaseImageUrl, ImageType.Cover, _configuration.ImageDefaultPlaceholder),
                    ProjectUrl = item.ProjectUrl,
                    Description = item.LongDescription.HtmlToPlainText()
                });
            }

            var model = newList.GetPaged<ProjectModel>(pageNumber, pageSize);
            model.SortOrder = (int) sortOrder;

            return model;
        }

        // GET api/<ProblemCategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ProjectModel> Get(string id)
        {
            var item = await _service.GetAsync(id);

            return new ProjectModel()
            {
                Id = item.Id,
                StartDate = item.StartDate.Value,
                EndDate = item.EndDate.Value,
                ProjectName = item.ProjectName,
                CoverImageUrl = item.GetPath(_configuration.BaseImageUrl, ImageType.Cover, _configuration.ImageDefaultPlaceholder),
                ProjectUrl = item.ProjectUrl,
                Description = item.LongDescription.HtmlToPlainText()
            };
        }
    }
}
