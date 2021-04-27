using System;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent(Name = "StudentCourses")]
    public class StudentCourses : ViewComponent
    {
        private readonly DbContext _context;

        public StudentCourses(DbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            try
            {
                var studentCourses = await _context.Set<StudentCourse>().Include(c => c.Course)
                    .Where(c => c.StudentId == id).ToListAsync();
                return View(studentCourses);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
