using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Employment.Base.ApiModels;
using Employment.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Iqt.Base.Enums;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private readonly DbContext _context;

        public EmployeesController(DbContext context, IApplicationConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public PagedResult<EmployeeModel> Get(int? page = null, int? size = null, int? sort = null)
        {
            var sortOrder = sort != null ? (SortOrder)sort : SortOrder.None;
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;
            var employees = _context.Set<Employee>().Include(c => c.Images).ToList();

            if (sortOrder == SortOrder.NameAssending)
            {
                employees = employees.OrderBy(c => c.Names.FirstName).ToList();
            }
            else if (sortOrder == SortOrder.NameDesending)
            {
                employees = employees.OrderByDescending(c => c.Names.FirstName).ToList();
            }

            var newList = new List<EmployeeModel>();

            foreach (var employee in employees)
            {
                newList.Add(new EmployeeModel()
                {
                    Id = employee.Id,
                    FirstName = employee.Names.FirstName,
                    LastName = employee.Names.LastName,
                    Designation = employee.WorkTitle,
                    Description = employee.Description,
                    ImageUrl = employee.GetPath(_configuration.BaseImageUrl, ImageType.Cover, "images/placeholders/profileImage128x128.png"),
                    Email = employee.EmailAddresses.FirstOrDefault(c => c.Default)?.Address,
                    FacebookUrl = employee.SocialMedia.Facebook,
                    TwitterUrl = employee.SocialMedia.Twitter,
                    LinkedInUrl = employee.SocialMedia.Linkedin
                });
            }

            var model = newList.GetPaged(pageNumber, pageSize);
            model.SortOrder = (int)sortOrder;

            return model;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
