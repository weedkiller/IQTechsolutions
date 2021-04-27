using System.Threading.Tasks;
using GoogleReCaptcha.V3.Interface;
using Iqt.Base.Enums.Support;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Feedback.Models;
using Iqt.Feedback.Services;
using Iqt.MailingService.Email;
using Iqt.MailingService.Interfaces;
using IQTechFramework.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ReSharper disable Mvc.ActionNotResolved
// ReSharper disable Mvc.ControllerNotResolved
// ReSharper disable Mvc.ViewNotResolved
// ReSharper disable Mvc.AreaNotResolved

namespace Iqt.Core.Controllers
{
    /// <summary>
    /// The home controller for ticketing system
    /// </summary>
    /// <typeparam name="TEntity">The owner type of the ticket</typeparam>
    public class TicketBaseController<TEntity> : Controller where TEntity : IEntityBase, new()  
    {
        /// <summary>
        /// The controller context service
        /// </summary>
        private readonly TicketContextService<TEntity> _service;

        private readonly ICaptchaValidator _captchaValidator;

        /// <summary>
        /// The default email template sender
        /// </summary>
        private readonly IEmailTemplateSender _emailSender;

        /// <summary>
        /// The default constructor
        /// </summary>
        public TicketBaseController(TicketContextService<TEntity> service, IEmailTemplateSender emailSender, ICaptchaValidator captchaValidator)
        {
            _service = service;
            _emailSender = emailSender;
            _captchaValidator = captchaValidator;
        }

        /// <summary>
        /// The method to setup the index view
        /// GET: Support/Home
        /// </summary>
        /// <returns>The index view</returns> 
        public async Task<IActionResult> Index()
        {
            // Get a list of the tickets
            var model = await _service.GetAll().ToListAsync();
            return View(model);
        }

        /// <summary>
        /// The method to setup the list view
        /// GET: Support/Home
        /// </summary>
        /// <returns>The index view</returns> 
        public async Task<IActionResult> List()
        {
            // Get a list of the tickets
            var model = await _service.GetAll().ToListAsync();
            return View(model);
        }

        /// <summary>
        /// The method to setup the details view
        /// GET: Support/Home/Details/{id}
        /// </summary>
        /// <param name="id">The identity of the ticket to be listed</param>
        /// <returns>The details view</returns>
        public async Task<IActionResult> Details(string id)
        {
            // Check to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the ticket
            var supportTicket = await _service.GetAsync(id);

            // Check to see if the support ticket exist
            if (supportTicket == null)
            {
                return NotFound();
            }

            //Return the detials view
            return View(supportTicket);
        }

        #region Create

        /// <summary>
        /// The method to setup the create view (Also named the contact form)
        /// GET: Support/Home/Create
        /// </summary>
        /// <param name="parentId">The identity of the parent of this support ticket</param>
        /// <returns>The create view</returns>
        [AllowAnonymous]
        public IActionResult Create(string parentId)
        {
            var model = new TicketAddEditModel()
            {
                ParentId = parentId,
                Priority = Priority.Low
            };
            return View(model);
        }

        /// <summary>
        /// The method the post the ticket to the server
        /// POST: Support/Home/Create
        /// </summary>
        /// <param name="model">The model of the ticket that should be created</param>
        /// <returns>The index view if successful, else the same view and model</returns>
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketAddEditModel model)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(model.Captcha))
            {
                ModelState.AddModelError("Captcha", "Captcha validation failed");
            }
            // Check for validation
            if (ModelState.IsValid)
            {
                var entity = await _service.AddAsync(model);

                // Create callback-url for the email
                var callbackUrl = Url.Action("Details", "Home", new { area = "Support", id = entity.Id }, protocol: Request.Scheme);

                // Send the verification mails
                await _emailSender.SendGeneralEmailAsync(new SendEmailDetails($"{entity.FirstName} {entity.LastName}", entity.EmailAddress, $"Thank You for submitting a support request - {FrameworkDI.Configuration["Company:Name"]}", FrameworkDI.Configuration["EmailSettings:SendEmailFromName"], FrameworkDI.Configuration["EmailSettings:AdminAddress"]),
                    "Thank You",
                    $"Hi {entity.FirstName} {entity.LastName},",
                    $"Thank you for submitting a review with us.<br/> A service representative will get back to you shortly if necessary.",
                    "Go to Support Ticket",
                    callbackUrl
                );
                await _emailSender.SendGeneralEmailAsync(new SendEmailDetails($"{entity.FirstName} {entity.LastName}", FrameworkDI.Configuration["EmailSettings:AdminAddress"], $"Support Ticket {FrameworkDI.Configuration["EmailSettings:SendEmailFromName"]} from {entity.FirstName} {entity.LastName}", FrameworkDI.Configuration["Company:Name"], FrameworkDI.Configuration["EmailSettings:AdminAddress"]),
                    $"Support Ticket Submitted by {entity.FirstName} {entity.LastName}",
                    "Hi Administrator,",
                    $"{entity.FirstName} {entity.LastName} submitted a support request with the following details.<br/>" +
                    $"<strong>Subject : </strong> {entity.Subject}.<br/> " +
                    $"<strong>Email : </strong> {entity.EmailAddress}.<br/> " +
                    $"<strong>Telephone : </strong> {entity.CellNr}.<br/> " +
                    $"<strong>Details : </strong> {entity.Content}.",
                    "Go to Support Ticket",
                    callbackUrl
                );

                ViewBag.Description = "Thank You for Submitting your support ticket.";
                ViewBag.Message = "A service representative will get back to you shortly!";

                // Return the index view
                return View("ThanksForSubmitting");
            }
            return View(model);
        }

        #endregion

        #region Quote

        /// <summary>
        /// The method to setup the Quote view (Also named the Quotation form)
        /// GET: Support/Home/Create
        /// </summary>
        /// <param name="parentId">The identity of the parent of this support ticket</param>
        /// <returns>The Quote view</returns>
        [AllowAnonymous]
        public IActionResult Quote(string parentId)
        {
            var model = new TicketAddEditModel()
            {
                ParentId = parentId,
                Priority = Priority.Low
            };
            return View(model);
        }

        /// <summary>
        /// The method the post the ticket to the server
        /// POST: Support/Home/Quote
        /// </summary>
        /// <param name="model">The model of the ticket that should be created</param>
        /// <returns>The index view if successful, else the same view and model</returns>
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Quote(TicketAddEditModel model)
        {
            // Check for validation
            if (ModelState.IsValid)
            {
                var entity = await _service.AddAsync(model);

                // Create callback-url for the email
                var callbackUrl = Url.Action("Details", "Home", new { area = "Support", id = entity.Id }, protocol: Request.Scheme);

                // Send the verification mails
                await _emailSender.SendGeneralEmailAsync(new SendEmailDetails($"{entity.FirstName} {entity.LastName}", entity.EmailAddress, FrameworkDI.Configuration["EmailSettings:AdminAddress"], FrameworkDI.Configuration["Company:Name"], $"Thank You for submitting a support reqeust - {FrameworkDI.Configuration["EmailSettings:SendEmailFromName"]}"),
                    "Thank You",
                    $"Hi {entity.FirstName} {entity.LastName},",
                    $"Thank you for submitting a review with us.<br/> A {FrameworkDI.Configuration["Company:Name"]} service representative will get back to you shortly if neccisary.",
                    "Go to Support Ticket",
                    callbackUrl
                );
                await _emailSender.SendGeneralEmailAsync(new SendEmailDetails($"{entity.FirstName} {entity.LastName}", FrameworkDI.Configuration["EmailSettings:AdminAddress"], FrameworkDI.Configuration["EmailSettings:AdminAddress"], FrameworkDI.Configuration["Company:Name"], $"Support Ticket {FrameworkDI.Configuration["EmailSettings:SendEmailFromName"]} from {entity.FirstName} {entity.LastName}"),
                    $"Support Ticket Submitted by {entity.FirstName} {entity.LastName}",
                    "Hi Administrator,",
                    $"{entity.FirstName} {entity.LastName} submitted a support request with the following details.<br/>" +
                    $"<strong>Subject : </strong> {entity.Subject}.<br/> " +
                    $"<strong>Email : </strong> {entity.EmailAddress}.<br/> " +
                    $"<strong>Telephone : </strong> {entity.CellNr}.<br/> " +
                    $"<strong>Details : </strong> {entity.Content}.",
                    "Go to Support Ticket",
                    callbackUrl
                );

                ViewBag.Description = "Thank You for Submitting your support ticket.";
                ViewBag.Message = "A service representative will get back to you shortly!";

                // Return the index view
                return View("ThanksForSubmitting");
            }
            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit ticket view
        /// GET: Support/Home/Edit/{id}
        /// </summary>
        /// <param name="id">The id of the ticket to be updated</param>
        /// <returns>The edit ticket view with the relevant ticket</returns>
        public async Task<IActionResult> Edit(string id)
        {
            // Check to see if the id field is populated
            if (id == null)
            {
                return NotFound();
            }

            // Get the support Ticket
            var supportTicket = await _service.GetAsync(id);

            // Check if the support ticket exist
            if (supportTicket == null)
            {
                return NotFound();
            }

            // Create new model
            var model = new TicketAddEditModel()
            {
                Id = supportTicket.Id,
                FirstName = supportTicket.FirstName,
                LastName = supportTicket.LastName,
                EmailAddress = supportTicket.EmailAddress,
                PhoneNr = supportTicket.CellNr,
                Subject = supportTicket.Subject,
                Content = supportTicket.Content,
                TicketStatus = supportTicket.TicketStatus,
                Priority = supportTicket.Priority,
                Files = supportTicket.Files
            };

            // Return the edit view
            return View(model);
        }

        /// <summary>
        /// The method used to post to the update post to the server
        /// POST: Support/Home/Edit/{id}
        /// </summary>
        /// <param name="model">The model that the post is being updated from</param>
        /// <returns>The edit view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TicketAddEditModel model)
        {
            // Chekc for validation errors
            if (ModelState.IsValid)
            {
                var entity = await _service.UpdateAsync(model);

                // Create callback-url for the email
                var callbackUrl = Url.Action("Details", "Home", new {area = "Support", id = entity.Id},
                    protocol: Request.Scheme);
                await _emailSender.SendGeneralEmailAsync(
                    new SendEmailDetails($"{entity.FirstName} {entity.LastName}",
                        FrameworkDI.Configuration["EmailSettings:AdminAddress"],
                        FrameworkDI.Configuration["EmailSettings:AdminAddress"], FrameworkDI.Configuration["Company:Name"],
                        $"Support Ticket {entity.Subject} changed"),
                    $"Support Ticket {entity.Id} was changed",
                    "Hi Administrator,",
                    $"{entity.Id} was edited and changed to the following details.<br/>" +
                    $"<strong>Subject : </strong> {entity.Subject}.<br/> " +
                    $"<strong>Email : </strong> {entity.EmailAddress}.<br/> " +
                    $"<strong>Telephone : </strong> {entity.CellNr}.<br/> " +
                    $"<strong>Details : </strong> {entity.Content}.",
                    "Go to Support Ticket",
                    callbackUrl
                );

                // Return the index view
                return RedirectToAction(nameof(List));
            }

            // If validation errors return same view and model with errors
            return View(model);
        }

        #endregion

        #region Delete

        /// <summary>
        /// The method used to setup the Delete Page
        ///  GET: Support/Home/Delete/{id}
        /// </summary>
        /// <param name="id">The ticket that should be deleted</param>
        /// <returns>The page that shows the page to delete the ticket</returns>
        public async Task<IActionResult> Delete(string id)
        {
            // Get the support ticket
            var supportTicket = await _service.GetAsync(id);
            // Check if the support ticket exist
            var model = new ModalModel()
            {
                HeaderString = $"Are you sure you want to delete Blog Entry with id {supportTicket.Id}",
                ControllerUrl = "/Support/Home/Delete",
                EntityId = supportTicket.Id
            };

            return PartialView("Modals/_DeleteModal", model);
        }

        // POST: Support/Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);

            // Get a list of all the blog sub-categories in json format
            var y = Json(true);
            // Return the Json
            return y;
        }

        #endregion
    }
}