using Education.Base.ApiModels;
using Education.Base.Entities;
using Iqt.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filing.Base.Enums;
using Filing.Base.Extensions;

namespace Metsi.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private IApplicationConfiguration _configuration;
        private DbContext _context;

        /// <summary>
        /// Default Constructor     
        /// </summary>
        /// <param name="context">The injected <see cref="DbContext"/></param>
        /// <param name="configuration">The injected <see cref="IApplicationConfiguration"/></param>
        public ModulesController(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list of all the modules that belong to a specific course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpGet("GetModules")]
        public async Task<List<ModuleApiModel>> GetModules(string courseId)
        {
            var moduleList = await _context.Set<Module>().Include(c => c.Sections).Where(c => c.CourseId == courseId).ToListAsync();
            var resultList = new List<ModuleApiModel>();

            foreach (var module in moduleList)
            {
                resultList.Add(new ModuleApiModel()
                {
                    Id = module.Id,
                    Name = module.Name,
                    Description = module.Description,
                    SectionCount = module.Sections.Count,
                    CourseId = module.CourseId
                });
            }

            return resultList;
        }

        [HttpGet("GetModule")]
        public async Task<ModuleApiModel> GetModule(string moduleId)
        {
            var module = await _context.Set<Module>().Include(c => c.Sections).FirstOrDefaultAsync(c => c.Id == moduleId);
            var resultList = new ModuleApiModel()
            {
                Id = module.Id,
                Name = module.Name,
                ImageUrl = module.GetImage(ImageType.Cover)?.RelativePath,
                Description = module.Description,
                SectionCount = module.Sections.Count,
                CourseId = module.CourseId
            };

            return resultList;
        }

        [HttpGet("GetSections")]
        public async Task<List<SectionApiModel>> GetSections(string moduleId)
        {
            var sectionList = await _context.Set<Section>().Include(c => c.Sections).Where(c => c.ModuleId == moduleId).ToListAsync();
            var resultList = new List<SectionApiModel>();

            foreach (var section in sectionList)
            {
                resultList.Add(new SectionApiModel()
                {
                    Id = section.Id,
                    Name = section.Name,
                    Description = section.Description,
                    ChildSectionCount = section.Sections.Count,
                    ParentId = section.ModuleId ?? section.ParentSectionId
                });
            }

            return resultList;
        }
    }
}
