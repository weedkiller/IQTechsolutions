using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Employment.Base.Entities;
using Identity.Base.Entities;
using Mailing.Base.Interfaces;
using Metsi.Web.Admin.Models;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Syncfusion.EJ2.FileManager.Base;
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;

namespace Metsi.Web.Admin.Areas.FileManager.Controllers
{
    [Area("FileManager")]
    [Route("FileManager/[controller]/[action]")]
    public class HomeController : Controller
    {
        private DbContext _context;

        public PhysicalFileProvider operation { get; set; }

        public string basePath { get; set; }

        // Root Path in which files and folders are available.
        string root = "wwwroot\\Files";

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
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
        public IActionResult ShareFileFolder([FromBody] SelectedFile details)
        {
            var employees = _context.Set<UserInfo>();

            var model = new ShareFileFolderModel()
            {
                Employees = new SelectList(employees, "Id", "UserName")
            };
            foreach (var item in details.data)
            {
                model.FolderPath = item.FilterPath;
                model.SelectedFiles.Add(new SharedFolder()
                {
                    SharerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    FolderName = item.Name,
                    FolderPath = item.FilterPath + item.Name + "\\",
                    IsFile = item.IsFile,
                    RootPath = item.FilterPath
                });
            }

            return PartialView("Modals/_ShareFileFolderModal", model);
        }

        [HttpPost]
        public IActionResult ShareFileFolderByAddress([FromBody] SelectedFile details)
        {
            var model = new ShareFileFolderModel();
            foreach (var item in details.data)
            {
                model.FolderPath = item.FilterPath;
                model.SelectedFiles.Add(new SharedFolder()
                {
                    SharerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    FolderName = item.Name,
                    FolderPath = item.FilterPath + item.Name + "\\",
                    IsFile = item.IsFile,
                    RootPath = item.FilterPath
                });
            }

            return PartialView("Modals/_ShareFileFolderModalAddress", model);
        }

        [HttpPost("{id}")]
        public IActionResult DoShareFileFolder([FromBody]SharedFolder[] details, string id)
        {
            var employee = _context.Set<Employee>().FirstOrDefault(c => c.Id == id);
            foreach (var item in details)
            {
                item.SharedWithId = employee.UserInfoId;
            }

            return RedirectToAction("Index", new {path = details[0].RootPath});
        }

        [HttpPost("{mail}")]
        public async Task<IActionResult> DoShareFileFolderByAddress([FromBody] SharedFolder[] details, string mail, [FromServices] DefaultEmailSender emailSender)
        {
            foreach (var item in details)
            {
                item.SharedWithAddress = mail;

                var callbackUrl = Url.Page(
                    "/FileManager/Home/Geust",
                    pageHandler: null,
                    values: new { id = item.Id},
                    protocol: Request.Scheme);

                await emailSender.SendSharedUserFolderEmailAsync("Private User", item.FolderName,
                    item.SharedWithAddress, callbackUrl);
            }
            return RedirectToAction("Index", new { path = details[0].RootPath });
        }

        public IActionResult Index(string path = "")
        {
            if (string.IsNullOrEmpty(path))
            {
                if (User.IsInRole("Admin"))
                {
                    root = "wwwroot\\Files";
                }
                else
                {
                    root = "wwwroot\\Files\\" + path;
                }
            }
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Geust(string id)
        {
            var sharedFolder = await _context.Set<SharedFolder>().FirstOrDefaultAsync(c => c.Id == id);

            root = "wwwroot\\Files\\" + sharedFolder.FolderPath;
            return View();
        }
    }
}