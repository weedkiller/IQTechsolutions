using System;
using System.Drawing;
using System.Threading.Tasks;
using Feedback.Base.Entities;
using Feedback.Core.Models;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Olympia.Web.Site.Areas.Customers.Controllers
{
    [Area("Customers")]
    [Route("Customers/[controller]/[action]")]
    public class TestimonialsBaseController : Controller
    {
        protected DbContext Context;

        public TestimonialsBaseController(DbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var model = await Context.Set<Testimonial>().Include(c => c.Images).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = Context.Set<Testimonial>().Include(c => c.Images).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TestimonialAddEditModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TestimonialAddEditModel model, [FromServices] IFileFactory _fileFactory)
        {
            if (ModelState.IsValid)
            {
                Context.Add(model.Testimonial);
                var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Testimonial>(model.CoverUpload,
                    null, "images/uploads/testimonials/covers", ImageType.Cover,
                    new Point(Convert.ToInt16(model.CoverCropSettings.X),
                        Convert.ToInt16(model.CoverCropSettings.Y)),
                    new Size(Convert.ToInt16(model.CoverCropSettings.Width),
                        Convert.ToInt16(model.CoverCropSettings.Height)), model.Testimonial.Id);
                await Context.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var existingTestimonial = await Context.Set<Testimonial>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);
            var model = new TestimonialAddEditModel()
            {
                Testimonial = existingTestimonial
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TestimonialAddEditModel model, [FromServices] IFileFactory _fileFactory)
        {
            if (ModelState.IsValid)
            {
                var existingService = await Context.Set<Testimonial>().Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == model.Testimonial.Id);

                var cover = await _fileFactory.UploadImageAndSaveToDbAsync<Testimonial>(model.CoverUpload, existingService.GetImage()?.Id, "images/uploads/testimonials/covers", ImageType.Cover, new Point(Convert.ToInt16(model.CoverCropSettings.X), Convert.ToInt16(model.CoverCropSettings.Y)), new Size(Convert.ToInt16(model.CoverCropSettings.Width), Convert.ToInt16(model.CoverCropSettings.Height)), model.Testimonial.Id);

                Context.Entry(existingService).CurrentValues.SetValues(model.Testimonial);
                await Context.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}