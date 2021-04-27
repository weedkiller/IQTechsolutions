using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Education.Base.Entities;
using Education.Core.Context.Services;
using Education.Core.Models;
using Identity.Base.Entities;
using Iqt.Base.Entities;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Metsi.Web.Email;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable Mvc.PartialViewNotResolved
// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved

namespace Education.Core.Controllers
{
    public abstract class StudentBaseController : Controller
    {
        protected readonly StudentContext Service;
        protected readonly DefaultEmailSender EmailSender;
        protected readonly IApplicationConfiguration Configuration;

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context">The injected Student Context</param>
        /// <param name="emailSender">The injected email sender</param>
        /// <param name="configuration">The injected application configuration</param>
        public StudentBaseController(StudentContext context, DefaultEmailSender emailSender, IApplicationConfiguration configuration)
        {
            Service = context;
            EmailSender = emailSender;
            this.Configuration = configuration;
        }

        #endregion

        #region Indexes

        /// <summary>
        /// Gets the default list view
        /// GET: Employees/Home/List
        /// </summary>
        /// <returns>The default list view</returns>
        public IActionResult List()
        {
            var list = Service.GetAll().ToList();
            return View(list);
        }

        /// <summary>
        /// Gets the default index page
        /// GET: Employees/Home/Index
        /// </summary>
        /// <returns>The index view</returns>
        public IActionResult Index()
        {
            return View(Service.GetAll().ToList());
        }

        #endregion

        #region Details

        /// <summary>
        /// Gets the default Details page
        /// GET: Employees/Home/Details
        /// </summary>
        /// <param name="id">The identity of the employee to feature</param>
        /// <returns>The default details page with a featured employee model</returns>
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await Service.GetAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        #endregion

        #region Create

        /// <summary>
        /// Gets the default create view
        /// GET: Employees/Home/Create
        /// </summary>
        /// <returns>The default edit view</returns>
        public IActionResult Create()
        {
            var model = new StudentAddEditModel(new Student()
            {
                Id = Guid.NewGuid().ToString()
            });
            return View(model);
        }

        /// <summary>
        /// Posts a new employee to the server
        /// POST: Employees/Home/Create
        /// </summary>
        /// <param name="model">The model with the employee to be added to the database</param>
        /// <returns>The employee list view if successful otherwise the same view and model</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                var emailAddress = new EmailAddress<Student>(model.Email);
                emailAddress.Default = true;
                emailAddress.EntityId = model.Entity.Id;

                model.Entity.EmailAddresses.Add(emailAddress);
                
                var contactNr = new ContactNumber<Student>()
                {
                    Name = "Default Nr",
                    Default = true,
                    Number = model.PhoneNr,
                    EntityId = model.Entity.Id
                };
                model.Entity.ContactNumbers.Add(contactNr);

                model.Entity.PersonalFolder = Path.Combine("wwwroot\\Students", model.Entity.Names.ToString());
                model.Entity.Active = true;

                if (!Directory.Exists(model.Entity.PersonalFolder))
                    Directory.CreateDirectory(model.Entity.PersonalFolder);

                var callbackUrl =
                    $"{Configuration.BaseIdentityUrl}/Authentication/Register?returnUrl=https://training.metsi.co.za/home/dashboard&studentId=" + model.Entity.Id;

                await EmailSender.SendStudentRegistrationEmailAsync(model.Entity.Names.ToString(),
                    model.Entity.EmailAddresses.FirstOrDefault(c => c.Default)?.Address, callbackUrl,
                    "donotreply@admin.co.za", "Is20170804!!");
                    
                await Service.AddAsync(model);

                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// Gets the default edit view with a specific employee
        /// GET: Employees/Home/Edit/{Id}
        /// </summary>
        /// <returns>The default edit view</returns>
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = Service.GetAll().FirstOrDefault(c => c.Id == id);


            var model = new StudentAddEditModel()
            {
                Entity = student
            };

            //if (!string.IsNullOrEmpty(student.ApplicationUserId))
            //{
            //    model.UserName = student.ApplicationUser.UserName;
            //    model.Password = "*********";
            //}


            if (student == null)
            {
                return NotFound();
            }
            return View(model);
        }

        /// <summary>
        /// Posts a employee to the server for update
        /// POST: Employees/Home/Edit/{Id}
        /// </summary>
        /// <param name="model">The employee details to be updated to the database</param>
        /// <returns>The employee list view if successful otherwise the same view and model</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(model);

                return RedirectToAction(nameof(List));
            }
            return View(model);
        }

        #endregion

        #region Delete

        /// <summary>
        /// The default delete view
        /// GET: Employees/Home/Delete/{Id}
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>The default delete view</returns>
        public async Task<IActionResult> Delete(string id)
        {
            var entity =await Service.GetAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete problem ? " +
                               $"with id {entity.DisplayName} details",
                ControllerUrl = "/Courses/Students/Delete",
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Post to delete the employee from the database
        /// </summary>
        /// <param name="id">The identity of the employee to be deleted</param>
        /// <returns>A json bool result to indicate whether the removal was succesful</returns>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await Service.DeleteAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #region StudentCourses

        /// <summary>
        /// The default delete course view
        /// GET: Employees/Home/Delete/{Id}
        /// </summary>
        /// <param name="studentId">The identity of the student the course is registered</param>
        /// <param name="courseId">The identity of the course that is registered</param>
        /// <returns>The default delete student course view</returns>
        public async Task<IActionResult> DeleteStudentCourse(string studentId, string courseId)
        {
            var studentCourse = await Service.GetStudentCourse(studentId, courseId);

            var model = new ModalModel()
            {
                HeaderString = $"Are you sure you want unregistered {studentCourse.Course.Name} ? ",
                ControllerUrl = $"/Courses/Students/DeleteStudentCourse",
                
            };


            return PartialView("Modals/_DeleteObjectModal", model);
        }

        /// <summary>
        /// Post to delete the student course from the database
        /// </summary>
        /// <param name="studentId">The identity of the student the course is registered</param>
        /// <param name="courseId">The identity of the course that is registered</param>
        /// <returns>A json bool result to indicate whether the removal was succesful</returns>
        [HttpPost, ActionName("DeleteStudentCourse")]
        public async Task<IActionResult> DeleteStudentCourseConfirmed(string studentId, string courseId)
        {
            await Service.DeleteStudentCourse(studentId, courseId);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #region CreateContactNumber

        /// <summary>
        /// Gets create contact nr partial view and values
        /// </summary>
        /// <param name="personId">The identity of the parent</param>
        /// <returns>The create contact partial view</returns>
        public async Task<IActionResult> CreateContactNumber(string personId)
        {
            var contact = await Service.GetAsync(personId);

            if (contact == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this Employee before creating any contact numbers for it",
                    ControllerUrl = "/Courses/Students/CreateContactNumber"
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }
            var model = new ContactNumber<Student>()
            {
                EntityId = personId
            };
            // Return the view with the model
            return PartialView("_CreateContactNumber", model);
        }

        /// <summary>
        /// Posts the created contact number values to the server
        /// </summary>
        /// <param name="model">The model used for the values to post to the server</param>
        /// <returns>Json entity if successful otherwise the create contact partial view</returns>
        [HttpPost]
        public async Task<IActionResult> CreateContactNumber(ContactNumber<Student> model)
        {
            if (ModelState.IsValid)
            {
                var entity = await Service.AddContactNrAsync(model);
                var y = Json(new { id = entity.Id, name = entity.Name, number = entity.Number, defaultEntry = entity.Default });
                return y;
            }
            return PartialView("_CreateContactNumber", model);
        }

        #endregion

        #region EditContactNumber

        /// <summary>
        /// Get the edit contact number partial view and values
        /// </summary>
        /// <param name="id">The identity of the contact number that must be updated</param>
        /// <param name="parentId">The identity of the parent</param>
        /// <returns>The edit contact partial view</returns>
        public async Task<IActionResult> EditContactNumber(string id, string parentId)
        {
            // Get the correct service entry
            var contactNr = await Service.GetContactNumber(id);

            // Check if the blogentry exist
            if (contactNr == null)
            {
                return NotFound();
            }

            var model = new ContactNumber<Student>()
            {
                Id = contactNr.Id,
                Name = contactNr.Name,
                InternationalCode = contactNr.InternationalCode,
                AreaCode = contactNr.AreaCode,
                Number = contactNr.Number,
                Default = contactNr.Default,
                EntityId = contactNr.EntityId
            };

            return PartialView("_EditContactNumber", model);
        }

        /// <summary>
        /// Posts the updated contact number details to the server for update to the database
        /// </summary>
        /// <param name="model">The model used for the update values</param>
        /// <returns>Json entity if successful otherwise the edit partial view with values</returns>
        [HttpPost]
        public async Task<IActionResult> EditContactNumber(ContactNumber<Student> model)
        {
            if (ModelState.IsValid)
            {
                var entity = await Service.EditContactNrAsync(model);
                

            }
            return PartialView("_EditContactNumber", model);
        }

        #endregion

        #region Delete Contact Number

        /// <summary>
        /// Gets the delete contact nr conformation partial view
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>The delete contact conformation partial</returns>
        public async Task<ActionResult> DeleteContactNumber(string id)
        {
            var entity = await Service.GetContactNumber(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this contact number ? ",
                ControllerUrl = "/Courses/Students/DeleteContactNumber",
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Posts the delete command to the server for removal of the entity from the database
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>Json true if successful</returns>
        [HttpPost, ActionName("DeleteContactNumber")]
        public async Task<ActionResult> DeleteConfirmedContactNumber(string id)
        {
            await Service.RemoveContactNumberAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #region CreateEmailAddress

        /// <summary>
        /// Gets create email address partial view and values
        /// </summary>
        /// <param name="personId">The identity of the parent</param>
        /// <returns>The create email address partial view</returns>
        public async Task<IActionResult> CreateEmailAddress(string personId)
        {
            var contact = await Service.GetAsync(personId);

            if (contact == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this Contact before creating any contact numbers for it",
                    ControllerUrl = "/Courses/Students/CreateEmailAddress"
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }
            var model = new EmailAddress<Student>()
            {
                EntityId = personId
            };
            // Return the view with the model
            return PartialView("_CreateEmailAddress", model);
        }

        /// <summary>
        /// Posts the created email address values to the server
        /// </summary>
        /// <param name="model">The model used for the values to post to the server</param>
        /// <returns>Json entity if successful otherwise the create email address partial view</returns>
        [HttpPost]
        public async Task<IActionResult> CreateEmailAddress(EmailAddress<Student> model)
        {
            if (ModelState.IsValid)
            {
                var entity = await Service.AddEmailAddressAsync(model);
                var y = Json(new { id = entity.Id, address = entity.Address, defaultEntry = entity.Default });
                return y;
            }
            return PartialView("_CreateEmailAddress", model);
        }

        #endregion

        #region EditEmailAddress

        /// <summary>
        /// Get the edit email address partial view and values
        /// </summary>
        /// <param name="id">The identity of the email address that must be updated</param>
        /// <param name="parentId">The identity of the parent</param>
        /// <returns>The edit contact partial view</returns>
        public async Task<IActionResult> EditEmailAddress(string id, string parentId)
        {
            // Get the correct service entry
            var contactNr = await Service.GetEmailAddressAsync(id);

            // Check if the blogentry exist
            if (contactNr == null)
            {
                return NotFound();
            }

            var model = new EmailAddress<Student>()
            {
                Id = contactNr.Id,
                Address = contactNr.Address,
                Default = contactNr.Default,
                EntityId = parentId
            };

            return PartialView("_EditEmailAddress", model);
        }

        /// <summary>
        /// Posts the updated email address details to the server for update to the database
        /// </summary>
        /// <param name="model">The model used for the update values</param>
        /// <returns>Json entity if successful otherwise the edit partial view with values</returns>
        [HttpPost]
        public async Task<IActionResult> EditEmailAddress(EmailAddress<Student> model)
        {
            if (ModelState.IsValid)
            {
                var entity = await Service.EditEmailAddressAsync(model);
                string bbbb = "fa-check";
                if (!entity.Default)
                {
                    bbbb = "fa-times";
                }

                return Json(new { id = entity.Id, parentId = entity.EntityId, name = entity.Address, address = entity.Address, defaultvalue = bbbb });

            }
            return PartialView("_EditEmailAddress", model);
        }

        #endregion

        #region Delete Email Address

        /// <summary>
        /// Gets the delete email address conformation partial view
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>The delete email address conformation partial</returns>
        public async Task<ActionResult> DeleteEmailAddress(string id)
        {
            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this contact number ? ",
                ControllerUrl = "/Courses/Students/DeleteEmailAddress",
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Posts the delete command to the server for removal of the entity from the database
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>Json true if successful</returns>
        [HttpPost, ActionName("DeleteEmailAddress")]
        public async Task<ActionResult> DeleteConfirmedEmailAddress(string id)
        {
            await Service.RemoveEmailAddressAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion

        #region Create Address

        /// <summary>
        /// Gets create address partial view and values
        /// </summary>
        /// <param name="personId">The identity of the parent</param>
        /// <returns>The create address partial view</returns>
        public async Task<IActionResult> CreateAddress(string personId)
        {
            var contact = await Service.GetAsync(personId);

            if (contact == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this Contact before creating any contact numbers for it",
                    ControllerUrl = "/Courses/Students/CreateAddress"
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }
            var model = new Address<Student>()
            {
                EntityId = personId
            };
            // Return the view with the model
            return PartialView("_CreateAddress", model);
        }

        /// <summary>
        /// Posts the created address number values to the server
        /// </summary>
        /// <param name="model">The model used for the values to post to the server</param>
        /// <returns>Json entity if successful otherwise the create contact partial view</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAddress(Address<Student> model)
        {
            if (ModelState.IsValid)
            {
                var entity = await Service.AddAddressAsync(model);
                var y = Json(new { id = entity.Id, addressLine = entity.ToString(), defaultEntry = entity.Default });
                return y;
            }
            return PartialView("_CreateAddress", model);
        }

        #endregion

        #region Edit Address

        /// <summary>
        /// Get the edit address partial view and values
        /// </summary>
        /// <param name="id">The identity of the address that must be updated</param>
        /// <param name="parentId">The identity of the parent</param>
        /// <returns>The edit address partial view</returns>
        public async Task<IActionResult> EditAddress(string id, string parentId)
        {
            // Get the correct service entry
            var address = await Service.GetAddressAsync(id);

            // Check if the blogentry exist
            if (address == null)
            {
                return NotFound();
            }

            var model = new Address<Student>()
            {
                Id = address.Id,
                Name = address.Name,
                UnitNumber = address.UnitNumber,
                Complex = address.Complex,
                StreetNumber = address.StreetNumber,
                AddressLine1 = address.AddressLine1,
                Suburb = address.Suburb,
                City = address.City,
                Province = address.Province,
                Country = address.Country,
                Location = new Location()
                {
                    Longitude = address.Location.Longitude,
                    Latitude = address.Location.Latitude
                },
                Default = address.Default,
                EntityId = parentId
            };

            return PartialView("_EditAddress", model);
        }

        /// <summary>
        /// Posts the updated address details to the server for update to the database
        /// </summary>
        /// <param name="model">The model used for the update values</param>
        /// <returns>Json entity if successful otherwise the edit partial view with values</returns>
        [HttpPost]
        public async Task<IActionResult> EditAddress(Address<Student> model)
        {
            if (ModelState.IsValid)
            {
                var entity = await Service.EditAddressAsync(model);
                //string bbbb = "fa-check";
                //if (!entity.Default)
                //{
                //    bbbb = "fa-times";
                //}

                var y = Json(new { id = entity.Id, addressLine = entity.ToString(), defaultEntry = entity.Default });
                return y;

            }
            return PartialView("_EditAddress", model);
        }

        #endregion

        #region Delete Address

        /// <summary>
        /// Gets the delete address conformation partial view
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>The delete contact conformation partial</returns>
        public async Task<ActionResult> DeleteAddress(string id)
        {
            var entity = await Service.GetAddressAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this contact number ? ",
                ControllerUrl = "/Courses/Students/DeleteAddress",
                EntityId = id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        /// <summary>
        /// Posts the delete command to the server for removal of the entity from the database
        /// </summary>
        /// <param name="id">The identity of the entity to be deleted</param>
        /// <returns>Json true if successful</returns>
        [HttpPost, ActionName("DeleteAddress")]
        public async Task<ActionResult> DeleteConfirmedAddress(string id)
        {
            await Service.RemoveAddressAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}