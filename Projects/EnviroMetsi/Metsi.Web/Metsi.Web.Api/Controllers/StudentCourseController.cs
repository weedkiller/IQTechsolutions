using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Filing.Base.Extensions;
using Identity.Base.Entities;
using Iqt.Base.Extensions;
using Iqt.Base.Models;
using Microsoft.EntityFrameworkCore;
using Education.Base.ApiModels;
 using Filing.Base.Enums;

 namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IApplicationConfiguration _configuration;
        private readonly DbContext _context;

        public StudentCourseController(IApplicationConfiguration configuration, DbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: api/<StudentController>
        [HttpGet("GetPaged")]
        public PagedResult<StudentCourseApiModel> GetPaged(string studentId, int? page = null, int? size = null)
        {
            var pageNumber = page ?? 1;
            var pageSize = size ?? 12;

            var studentCourses = _context.Set<StudentCourse>()
                .Include(c => c.Course).ThenInclude(c => c.Modules)
                .Include(c => c.Course).ThenInclude(c => c.Images)
                .Include(c => c.CompletedModules).Where(c => c.StudentId == studentId);

            var studentCourseListApiModelList = new List<StudentCourseApiModel>();

            foreach (var studentCourse in studentCourses)
            {
                var newStudentApiModel = new StudentCourseApiModel()
                {
                    StudentId = studentCourse.StudentId,
                    CourseId = studentCourse.CourseId,
                    ImageUrl = studentCourse.Course.GetPath(_configuration.BaseImageUrl, ImageType.Cover,_configuration.ImageDefaultPlaceholder),
                    Name = studentCourse.Course.Name,
                    Description = studentCourse.Course.Description.HtmlToPlainText().TruncateLongString(150),
                    CompletedPercentage = studentCourse.CompletedPercentage,
                    CurrentModuleId = studentCourse.CurrentModuleId,
                    Started = studentCourse.Started,
                    ModulesCount = studentCourse.Course.Modules.Count
                };

                studentCourseListApiModelList.Add(newStudentApiModel);
            }

            var model = studentCourseListApiModelList.GetPaged<StudentCourseApiModel>(pageNumber, pageSize);

            return model;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<StudentCourseApiModel>> Get([FromQuery]string studentId)
        {
            var userInfo = await _context.Set<UserInfo>().FirstOrDefaultAsync(c => c.Id == studentId);


            var studentCourses = _context.Set<StudentCourse>()
                .Include(c => c.Course).ThenInclude(c => c.Modules)
                .Include(c => c.Course).ThenInclude(c => c.Images)
                .Include(c => c.CompletedModules).Where(c => c.StudentId == userInfo.StudentId);

            var model = new List<StudentCourseApiModel>();

            foreach (var studentCourse in studentCourses)
            {
                var newStudentApiModel = new StudentCourseApiModel()
                {
                    StudentId = studentCourse.StudentId,
                    CourseId = studentCourse.CourseId,
                    ImageUrl = studentCourse.Course.GetPath(_configuration.BaseImageUrl, ImageType.Cover, _configuration.ImageDefaultPlaceholder),
                    Name = studentCourse.Course.Name,
                    CurrentModuleId = studentCourse.CurrentModuleId,
                    Description = studentCourse.Course.Description.HtmlToPlainText().TruncateLongString(150),
                    CompletedPercentage = studentCourse.CompletedPercentage,
                    Started = studentCourse.Started,
                    ModulesCount = studentCourse.Course.Modules.Count
                };

                model.Add(newStudentApiModel);
            }
            return model.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("GetDetails")]
        public async Task<StudentCourseApiModel> GetDetails([FromQuery] string studentId, [FromQuery] string courseId)
        {
            var studentCourse = _context.Set<StudentCourse>()
                .Include(c => c.Course).ThenInclude(c => c.Modules)
                .Include(c => c.Course).ThenInclude(c => c.Images)
                .Include(c => c.CompletedModules).Where(c => c.StudentId == studentId).FirstOrDefault(c => c.CourseId == courseId);

            var newStudentApiModel = new StudentCourseApiModel()
            {
                StudentId = studentCourse.StudentId,
                CourseId = studentCourse.CourseId,
                ImageUrl = studentCourse.Course.GetPath(_configuration.BaseImageUrl, ImageType.Cover, _configuration.ImageDefaultPlaceholder),
                Name = studentCourse.Course.Name,
                CurrentModuleId = studentCourse.CurrentModuleId,
                Description = studentCourse.Course.Description.HtmlToPlainText().TruncateLongString(150),
                CompletedPercentage = studentCourse.CompletedPercentage,
                Started = studentCourse.Started,
                ModulesCount = studentCourse.Course.Modules.Count
            };

            return newStudentApiModel;
        }
    }
}
