using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Iqt.Base.Entities;
using Iqt.Base.Models;
using Iqt.Filing.Interfaces;
using Iqt.Identity.Entities;
using Iqt.MailingService.Email;
using Iqt.MailingService.Interfaces;
using Iqt.Social.Models.Contacts;
using Iqt.Training.Entities;
using Iqt.Training.Interfaces;
using Iqt.Training.Models;
using IQTechFramework.Models.People.Contacts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable Mvc.PartialViewNotResolved
// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved

namespace Iqt.Core.Controllers
{
    public class StudentBaseController : Controller
    {
        private readonly IStudentContextService _context;

        private readonly UserManager<ApplicationUser> _userManager;

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context">The injected Database Context</param>
        public StudentBaseController(IStudentContextService context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            var list = _context.GetAll().ToList();
            return View(list);
        }

        /// <summary>
        /// Gets the default index page
        /// GET: Employees/Home/Index
        /// </summary>
        /// <returns>The index view</returns>
        public IActionResult Index()
        {
            return View(_context.GetAll().ToList());
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

            var employee = await _context.GetAsync(id);
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
            var model = new StudentAddEditModel(new Student());
            return View(model);
        }

        /// <summary>
        /// Posts a new employee to the server
        /// POST: Employees/Home/Create
        /// </summary>
        /// <param name="model">The model with the employee to be added to the database</param>
        /// <returns>The employee list view if successful otherwise the same view and model</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentAddEditModel model, [FromServices] IEmailSender _emailSender)
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

                if (!string.IsNullOrEmpty(model.UserName) && string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("Password", "Please enter a password when setting the username");
                    return View(model);
                }
                else if (string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("UserName", "Please enter a username when setting the password");
                    return View(model);
                }
                else if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
                {
                    var user = new ApplicationUser(model.Entity.Names.FirstName, model.Entity.Names.LastName, contactNr.Number, model.UserName, emailAddress.Address);
                    user.EmailConfirmed = true;
                    user.PersonalFolder = Path.Combine("wwwroot\\Files", model.UserName + "(" + model.Entity.Names.FirstName + " " + model.Entity.Names.LastName + ")");

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        var callbackUrl = Url.Page(
                            "/Profile/ConfirmEmail/Index",
                            pageHandler: null,
                            values: new { area = "Identity", id = user.Id },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(new SendEmailDetails("Enviro Metsi Web Admin",
                            "admin@metsi.co.za", @model.Entity.DisplayName,
                            model.Entity.EmailAddresses.FirstOrDefault(c => c.Default).Address,
                            "You have been registered as an employee at Enviro Metsi",
                            $"<h4>Your Credentials are:</h4><br/><br/>" +
                            $"<strong>Username : </strong>{model.UserName}<br/><br/>" +
                            $"<strong>Username : </strong>{model.UserName}<br/><br/>" +
                            $"You can access you profile by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.<br/><br/>"));

                        model.Entity.ApplicationUserId = user.Id;

                        if (!Directory.Exists(user.PersonalFolder))
                            Directory.CreateDirectory(user.PersonalFolder);
                    }
                }

                await _context.AddAsync(model);
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

            var student = _context.GetAll().FirstOrDefault(c => c.Id == id);


            var model = new StudentAddEditModel()
            {
                Entity = student
            };

            if (!string.IsNullOrEmpty(student.ApplicationUserId))
            {
                model.UserName = student.ApplicationUser.UserName;
                model.Password = "*********";
            }


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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentAddEditModel model, [FromServices] IEmailSender _emailSender)
        {
            if (ModelState.IsValid)
            {
                await _context.UpdateAsync(model);

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
            var entity =await _context.GetAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete problem ? " +
                               $"with id {entity.DisplayName} details",
                ControllerUrl = "/TrainingCourses/Students/Delete",
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
            await _context.DeleteAsync(id);
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
            var contact = await _context.GetAsync(personId);

            if (contact == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this Employee before creating any contact numbers for it",
                    ControllerUrl = "/TrainingCourses/Students/CreateContactNumber"
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }
            var model = new AddEditContactNumberDetailModel()
            {
                ParentId = personId
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
        public async Task<IActionResult> CreateContactNumber(AddEditContactNumberDetailModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.AddContactNrAsync(model);
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
            var contactNr = await _context.GetContactNumber(id);

            // Check if the blogentry exist
            if (contactNr == null)
            {
                return NotFound();
            }

            var model = new AddEditContactNumberDetailModel()
            {
                Id = contactNr.Id,
                Name = contactNr.Name,
                InternationalCode = contactNr.InternationalCode,
                AreaCode = contactNr.AreaCode,
                Number = contactNr.Number,
                Default = contactNr.Default,
                ParentId = parentId
            };

            return PartialView("_EditContactNumber", model);
        }

        /// <summary>
        /// Posts the updated contact number details to the server for update to the database
        /// </summary>
        /// <param name="model">The model used for the update values</param>
        /// <returns>Json entity if successful otherwise the edit partial view with values</returns>
        [HttpPost]
        public async Task<IActionResult> EditContactNumber(AddEditContactNumberDetailModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.EditContactNrAsync(model);
                string bbbb = "fa-check";
                if (!entity.Default)
                {
                    bbbb = "fa-times";
                }

                return Json(new { id = entity.Id, parentId = entity.EntityId, name = entity.Name, number = entity.Number, defaultvalue = bbbb });

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
            var entity = await _context.GetContactNumber(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this contact number ? ",
                ControllerUrl = "/TrainingCourses/Students/DeleteContactNumber",
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
            await _context.RemoveContactNumberAsync(id);
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
            var contact = await _context.GetAsync(personId);

            if (contact == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this Contact before creating any contact numbers for it",
                    ControllerUrl = "/TrainingCourses/Students/CreateEmailAddress"
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }
            var model = new AddEditEmailAddressModel()
            {
                ParentId = personId
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
        public async Task<IActionResult> CreateEmailAddress(AddEditEmailAddressModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.AddEmailAddressAsync(model);
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
            var contactNr = await _context.GetEmailAddressAsync(id);

            // Check if the blogentry exist
            if (contactNr == null)
            {
                return NotFound();
            }

            var model = new AddEditEmailAddressModel()
            {
                Id = contactNr.Id,
                Name = contactNr.Address,
                Address = contactNr.Address,
                Default = contactNr.Default,
                ParentId = parentId
            };

            return PartialView("_EditEmailAddress", model);
        }

        /// <summary>
        /// Posts the updated email address details to the server for update to the database
        /// </summary>
        /// <param name="model">The model used for the update values</param>
        /// <returns>Json entity if successful otherwise the edit partial view with values</returns>
        [HttpPost]
        public async Task<IActionResult> EditEmailAddress(AddEditEmailAddressModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.EditEmailAddressAsync(model);
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
                ControllerUrl = "/TrainingCourses/Students/DeleteEmailAddress",
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
            await _context.RemoveEmailAddressAsync(id);
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
            var contact = await _context.GetAsync(personId);

            if (contact == null)
            {
                var othermodel = new ModalModel()
                {
                    HeaderString = "Please save this Contact before creating any contact numbers for it",
                    ControllerUrl = "/TrainingCourses/Students/CreateAddress"
                };

                return PartialView("Modals/_PleaeSaveFirstModal", othermodel);
            }
            var model = new AddEditAddressDetailModel()
            {
                ParentId = personId
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
        public async Task<IActionResult> CreateAddress(AddEditAddressDetailModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.AddAddressAsync(model);
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
            var address = await _context.GetAddressAsync(id);

            // Check if the blogentry exist
            if (address == null)
            {
                return NotFound();
            }

            var model = new AddEditAddressDetailModel()
            {
                Id = address.Id,
                Name = address.Name,
                UnitNumber = address.UnitNumber,
                Complex = address.Complex,
                StreetNumber = address.StreetNumber,
                AddressLine = address.AddressLine1,
                Suburb = address.Suburb,
                City = address.City,
                Province = address.Province,
                Country = address.Country,
                Longtitude = address.Location.Longitude.ToString(),
                Latitude = address.Location.Latitude.ToString(),
                Default = address.Default,
                ParentId = parentId
            };

            return PartialView("_EditAddress", model);
        }

        /// <summary>
        /// Posts the updated address details to the server for update to the database
        /// </summary>
        /// <param name="model">The model used for the update values</param>
        /// <returns>Json entity if successful otherwise the edit partial view with values</returns>
        [HttpPost]
        public async Task<IActionResult> EditAddress(AddEditAddressDetailModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = await _context.EditAddressAsync(model);
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
            var entity = await _context.GetAddressAsync(id);

            var model = new ModalModel()
            {
                HeaderString = "Are you sure you want to delete this contact number ? ",
                ControllerUrl = "/TrainingCourses/Students/DeleteAddress",
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
            await _context.RemoveAddressAsync(id);
            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}