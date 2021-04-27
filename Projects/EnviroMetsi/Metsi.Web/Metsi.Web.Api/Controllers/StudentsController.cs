using Blogging.Base.Entities;
using Education.Core.Context.Services;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.ApiModels;
using Education.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Iqt.Base.Extensions;
using Iqt.Base.Models;

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IApplicationConfiguration _configuration;
        private readonly StudentContext _service;

        public StudentsController(IApplicationConfiguration configuration, StudentContext service)
        {
            _configuration = configuration;
            _service = service;
        }

        // GET: api/<StudentController>
        [HttpGet("GetPaged")]
        public PagedResult<StudentApiModel> GetPaged(int? page = null, int? size = null)
        {
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            IQueryable<Student> students = _service.GetAll();

            var studentListApiModelList = new List<StudentApiModel>();

            foreach (var student in students)
            {
                studentListApiModelList.Add(new StudentApiModel()
                {
                    Id = student.Id,
                    ImageUrl = student.UserInfo.GetPath(_configuration.BaseImageUrl, ImageType.Cover, _configuration.ImageProfilePlaceholder),
                    FirstName = student.Names.FirstName,
                    LastName = student.Names.LastName
                });
            }

            var model = studentListApiModelList.GetPaged<StudentApiModel>(pageNumber, pageSize);

            return model;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentApiModel> Get()
        {
            IQueryable<Student> students = _service.GetAll();

            var model = new List<StudentApiModel>();

            foreach (var student in students)
            {
                model.Add(new StudentApiModel()
                {
                    Id = student.Id,
                    ImageUrl = student.UserInfo.GetPath(_configuration.BaseImageUrl, ImageType.Cover, _configuration.ImageProfilePlaceholder),
                    FirstName = student.Names.FirstName,
                    LastName = student.Names.LastName
                });
            }
            return model.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<StudentApiModel> Get(string id)
        {
            var student = await _service.GetByUserIdAsync(id);
            return new StudentApiModel()
            {
                Id = student.Id,
                ImageUrl = student.UserInfo.GetPath(_configuration.BaseImageUrl, placeHolder: _configuration.ImageProfilePlaceholder),
                FirstName = student.Names.FirstName,
                LastName = student.Names.LastName
            };
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
