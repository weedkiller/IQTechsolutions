using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Extensions;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Base.ApiModels;
using Services.Base.Entities;
using Services.Core.Context.Services;

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private ServiceContext _service;

        public ServicesController(IApplicationConfiguration configuration, ServiceContext service)
        {
            _configuration = configuration;
            _service = service;
        }


        // GET: api/<ProblemsController>
        [HttpGet, AllowAnonymous]
        public PagedResult<ServiceModel> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Service> list = _service.GetAll();

            if (sortOrder == SortOrder.NameAssending)
            {
                list = list.OrderBy(c => c.Name);
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                list = list.OrderByDescending(c => c.Name);
            }

            var newList = new List<ServiceModel>();

            foreach (var item in list)
            {
                var newservice = new ServiceModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description.HtmlToPlainText(),
                    ImageUrl = item.GetPath("https://admin.metsi.co.za")
                };

                foreach (var image in item.Images)
                {
                    newservice.Images.Add(image.GetPath(_configuration.BaseImageUrl));
                }

                newList.Add(newservice);
            }

            var model = newList.GetPaged<ServiceModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }
        
        // GET api/<ProblemsController>/5
        [HttpGet("{id}")]
        public async Task<ServiceModel> Get(string id)
        {
            var entity = await _service.GetEntityAsync(id);
            var newservice = new ServiceModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description.HtmlToPlainText(),
                ImageUrl = entity.GetPath("https://admin.metsi.co.za")
            };

            foreach (var image in entity.Images)
            {
                newservice.Images.Add(image.GetPath(_configuration.BaseImageUrl));
            }
            return newservice;
        }

        // POST api/<ProblemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProblemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProblemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
