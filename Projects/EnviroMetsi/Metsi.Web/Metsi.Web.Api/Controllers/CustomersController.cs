using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers.Base.ApiModels;
using Customers.Base.Entities;
using Customers.Core.Context.Services;
using Filing.Base.Extensions;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Troubleshooting.Base.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private CustomerContext _context;
        private IApplicationConfiguration _configuration;

        public CustomersController(CustomerContext context, IApplicationConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<PagedResult<CustomerModel>> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Customer> list = _context.GetAll();

            var newList = new List<CustomerModel>();

            foreach (var item in list)
            {
                newList.Add(new CustomerModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.GetPath(_configuration.BaseImageUrl)
                });
            }

            var model = newList.GetPaged<CustomerModel>(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public CustomerModel Get(string id)
        {
            var entity = _context.GetEntity(id);
            return new CustomerModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description =  entity.Description,
                ImageUrl = entity.GetPath(_configuration.BaseImageUrl)
            };
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
