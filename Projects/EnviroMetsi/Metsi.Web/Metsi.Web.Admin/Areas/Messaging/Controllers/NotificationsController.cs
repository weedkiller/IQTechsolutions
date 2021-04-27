using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Feedback.Base.Entities;
using Filing.Base.Enums;
using Filing.Base.Extensions;
using Identity.Base.Entities;
using Iqt.Base.Interfaces;
using Messaging.Base.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metsi.Web.Admin.Areas.Messaging.Controllers
{
    /// <summary>
    /// The home controller for the notifications
    /// </summary>
    [Area("Messaging")]
    [Route("Messaging/[controller]/[action]")]
    public class NotificationsController : Controller
    {
        private readonly DbContext _dbContext;
        private readonly IApplicationConfiguration _configuration;

        #region Constructors

        public NotificationsController(DbContext dbContext, IApplicationConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        #endregion

        public IActionResult Index()
        {
            var notifications = _dbContext.Set<Notification>()
                .Where(c => c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(notifications);
        }

        /// <summary>
        /// Gets the create chat view
        /// </summary>
        /// <returns>The create view and relevant model</returns>
        [HttpGet]
        public async Task<IActionResult> CreateComment(string parentId = null)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _dbContext.Set<UserInfo>().FirstOrDefaultAsync();

            var entity = new NewsFeed()
            {
                ImageUrl = user.GetPath(_configuration.BaseImageUrl, ImageType.Cover, "/img/av1.png"),
                Subject = $"{user.FirstName} {user.LastName}",
                ParentFeedId = parentId
            };
            if (string.IsNullOrEmpty(parentId))
            {
                entity.UserId = user.Id;
            }

            return PartialView("_CreateComment", entity);
        }

        /// <summary>
        /// Posts the create model to the server
        /// </summary>
        /// <param name="model">The model to be posted to the server</param>
        /// <returns>The relevant view and model</returns>
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromForm] NewsFeed model)
        {
            // Check for any validation errors
            if (ModelState.IsValid)
            {
                _dbContext.Set<NewsFeed>().Add(model);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return PartialView("_CreateComment", model);
        }
    }
}
