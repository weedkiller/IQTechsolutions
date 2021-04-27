using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Education.Base.Entities;
using Education.Core.Context.Services;
using Education.Core.Controllers;
using Education.Core.Models;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Filing.Core.Factories;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Mailing.Base.Interfaces;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Syncfusion.EJ2.FileManager.Base;
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;

namespace Metsi.Web.Admin.Areas.Courses.Controllers
{
    /// <summary>
    /// The <see cref="Student"/> controller for the application
    /// </summary>
    [Area("Courses")]
    [Route("Courses/[controller]/[action]")]
    public class StudentsController : StudentBaseController
    {
        private DbContext _context;
        private IApplicationConfiguration _configuration;
        public PhysicalFileProvider operation;
        public string basePath;
        string root = "wwwroot\\Students";

        /// <summary>
        /// The default Constructor
        /// </summary>
        /// <param name="service">The injected training module service</param>
        public StudentsController(StudentContext service, IHostingEnvironment hostingEnvironment, DefaultEmailSender emailSender, DbContext context, IApplicationConfiguration configuration) : base(service, emailSender, configuration)
        {
            _context = context;
            _configuration = configuration;
            // Map the path of the files to be accessed with the host
            this.basePath = hostingEnvironment.ContentRootPath;
            this.operation = new PhysicalFileProvider();
            // Assign the mapped path as root folder
            this.operation.RootFolder(this.basePath + "\\" + this.root);
        }

        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            // Restricting modification of the root folder
            if (args.Action == "delete" || args.Action == "rename")
            {
                if ((args.TargetPath == null) && (args.Path == ""))
                {
                    FileManagerResponse response = new FileManagerResponse();
                    ErrorDetails er = new ErrorDetails
                    {
                        Code = "401",
                        Message = "Restricted to modify the root folder."
                    };
                    response.Error = er;
                    return this.operation.ToCamelCase(response);
                }
            }

            // Processing the File Manager operations
            switch (args.Action)
            {
                case "read":
                    // Path - Current path; ShowHiddenItems - Boolean value to show/hide hidden items
                    return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "delete":
                    // Path - Current path where of the folder to be deleted; Names - Name of the files to be deleted
                    return this.operation.ToCamelCase(this.operation.Delete(args.Path, args.Names));
                case "copy":
                    //  Path - Path from where the file was copied; TargetPath - Path where the file/folder is to be copied; RenameFiles - Files with same name in the copied location that is confirmed for renaming; TargetData - Data of the copied file
                    return this.operation.ToCamelCase(this.operation.Copy(args.Path, args.TargetPath, args.Names,
                        args.RenameFiles, args.TargetData));
                case "move":
                    // Path - Path from where the file was cut; TargetPath - Path where the file/folder is to be moved; RenameFiles - Files with same name in the moved location that is confirmed for renaming; TargetData - Data of the moved file
                    return this.operation.ToCamelCase(this.operation.Move(args.Path, args.TargetPath, args.Names,
                        args.RenameFiles, args.TargetData));
                case "details":
                    // Path - Current path where details of file/folder is requested; Name - Names of the requested folders
                    return this.operation.ToCamelCase(this.operation.Details(args.Path, args.Names));
                case "create":
                    // Path - Current path where the folder is to be created; Name - Name of the new folder
                    return this.operation.ToCamelCase(this.operation.Create(args.Path, args.Name));
                case "search":
                    // Path - Current path where the search is performed; SearchString - String typed in the searchbox; CaseSensitive - Boolean value which specifies whether the search must be casesensitive
                    return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString,
                        args.ShowHiddenItems, args.CaseSensitive));
                case "rename":
                    // Path - Current path of the renamed file; Name - Old file name; NewName - New file name
                    return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName));
            }

            return null;
        }

        // Processing the Upload operation
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            // Here we have restricted the upload operation for our online samples
            if (Response.HttpContext.Request.Host.Value == "ej2.syncfusion.com")
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = 403;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase =
                    "File Manager's upload functionality is restricted in the online demo. If you need to test upload functionality, please install Syncfusion Essential Studio on your machine and run the demo";
            }
            // Use below code for performing upload operation
            else
            {
                FileManagerResponse uploadResponse;
                //Invoking upload operation with the required paramaters
                // path - Current path where the file is to uploaded; uploadFiles - Files to be uploaded; action - name of the operation(upload)
                uploadResponse = operation.Upload(path, uploadFiles, action, null);
            }

            return Content("");
        }

        // Processing the Download operation
        public IActionResult Download(string downloadInput)
        {
            FileManagerDirectoryContent
                args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
            //Invoking download operation with the required paramaters
            // path - Current path where the file is downloaded; Names - Files to be downloaded;
            return operation.Download(args.Path, args.Names);
        }

        // Processing the GetImage operation
        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            //Invoking GetImage operation with the required paramaters
            // path - Current path of the image file; Id - Image file id;
            return this.operation.GetImage(args.Path, args.Id, false, null, null);
        }

        [HttpPost]
        public async Task<IActionResult> ResendRegistration(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = Service.GetAll().FirstOrDefault(c => c.Id == id);

            var callbackUrl =
                $"https://identity.metsi.co.za/Authentication/Register?returnUrl=https://training.metsi.co.za/home/dashboard&studentId={student.Id}";

            await EmailSender.SendStudentRegistrationEmailAsync(student.Names.ToString(),
                student.EmailAddresses.FirstOrDefault(c => c.Default)?.Address, callbackUrl,
                "donotreply@admin.co.za", "Is20170804!!");

            return Ok();
        }

        #region Delete

        /// <summary>
        /// The default delete view
        /// GET: Employees/Home/Delete/{Id}
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>The default delete view</returns>
        public async Task<IActionResult> ShowRegisterEmployeeModal(string studentId)
        {
            var courseSelectionList = new List<CheckBoxSelectionModel<Course>>();

            var entity = await Service.GetAsync(studentId);
            var courses = _context.Set<Course>().Include(c => c.Modules);
            foreach (var course in courses)
            {
                if (entity.Courses.All(c => c.CourseId != course.Id))
                {
                    courseSelectionList.Add(new CheckBoxSelectionModel<Course>(course));
                }
            }
            
            var model = new CourseRegistrationModel()
            {
                StudentId = studentId,
                AvailableCourses = courseSelectionList
            };

            return PartialView("_CourseRegistrationModal", model);
        }

        /// <summary>
        /// Post to delete the employee from the database
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>A json bool result to indicate whether the removal was succesful</returns>
        [HttpPost]
        public async Task<IActionResult> ShowRegisterEmployeeModal(CourseRegistrationModel model)
        {

            var resultList = new List<Course>();

            foreach (var course in model.AvailableCourses.Where(c => c.IsSelected))
            {
                var studentCourse = new StudentCourse()
                {
                    StudentId = model.StudentId,
                    CourseId = course.Entity.Id
                };
                _context.Set<StudentCourse>().Add(studentCourse);
                resultList.Add(course.Entity);    
            }
            await _context.SaveChangesAsync();

            // Get a list of all the blog sub-categories in json format
            var y = Json(resultList);

            return y;
        }

        #endregion
    }
}
