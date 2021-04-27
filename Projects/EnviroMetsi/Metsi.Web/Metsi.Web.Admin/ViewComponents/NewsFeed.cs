using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Feedback.Core.Context.Services;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Metsi.Web.Admin.ViewComponents
{
    [ViewComponent(Name = "NewsFeed")]
    public class NewsFeed : ViewComponent
    {
        private readonly NewsFeedContext _newsfeedService;

        public NewsFeed(NewsFeedContext newsfeedService)
        {
            _newsfeedService = newsfeedService;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool privateEntry)
        {
            if (privateEntry)
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var feedList = _newsfeedService.GetAllFeeds().OrderByDescending(c => c.Created);
                var newsFeed = feedList.Where(c => c.Private).Where(c => c.Id == userId).ToList();
                //foreach (var friend in _userManager.Users.Include(c => c.Friends).Where(c => c.Id == userId))
                //{
                //    newsFeed.AddRange(feedList.Where(c => c.Private).Where(c => c.Id == friend.Id));
                //}
                return View(newsFeed.OrderBy(c => c.Created));
            }
            return View(_newsfeedService.GetAllFeeds());
        }
    }
}
