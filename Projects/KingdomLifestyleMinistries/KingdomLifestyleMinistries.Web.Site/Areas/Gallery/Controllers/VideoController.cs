using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using IQTechSolutions.Filing.Interfaces;
using IQTechSolutions.Filing.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KingdomLifestyleMinistries.Web.Site.Areas.Gallery.Controllers
{
    [Area("Gallery")]
    [Route("Gallery/[controller]/[action]")]
    public class VideoController : Controller
    {
        #region Private Members

        /// <summary>
        /// The Repository manger for this controller
        /// </summary>
        private readonly IFileFactory _fileFactory;

        #endregion

        /// <summary>
        /// The default constructor 
        /// </summary>
        /// <param name="service">The injected context service</param>
        public VideoController(IFileFactory fileFactory)
        {
            _fileFactory = fileFactory;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var bb = await GetVideosFromChannelAsync("UC50syQ1NrWFXB0keDGGC4qQ");
            return View(bb.Where(c => c.Id.Kind == "youtube#video"));
        }

        /// <summary>
        /// Method used to set up the index page
        /// </summary>
        /// <returns>the index view</returns>
        public async Task<IActionResult> List()
        {
            var bb = await GetVideosFromChannelAsync("UC50syQ1NrWFXB0keDGGC4qQ");
            return View(bb.Where(c => c.Id.Kind == "youtube#video"));
        }

        /// <summary>
        /// This method sets up the detials view and model
        /// </summary>
        /// <param name="id">The identity of the video to be used</param>
        /// <returns>The specific video</returns>
        [AllowAnonymous]
        public async Task<ActionResult> Details(string id)
        {
            return View();
        }

        public Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
        {

            return Task.Run(() =>
            {
                List<SearchResult> res = new List<SearchResult>();

                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyDGQe6UI9b-y4NDGUO_FoOudQL7UnpxogA",
                    ApplicationName = "Kingdom Lifestyle Ministries"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                while (nextpagetoken != null)
                {
                    var searchListRequest = _youtubeService.Search.List("snippet");
                    searchListRequest.MaxResults = 50;
                    searchListRequest.ChannelId = ytChannelId;
                    searchListRequest.PageToken = nextpagetoken;

                    // Call the search.list method to retrieve results matching the specified query term.
                    var searchListResponse = searchListRequest.Execute();

                    // Process  the video responses 
                    res.AddRange(searchListResponse.Items);

                    nextpagetoken = searchListResponse.NextPageToken;

                }

                return res;

            });
        }

        public Task<IList<VideoCategory>> GetVideosCategoriesFromChannelAsync(string ytChannelId)
        {

            return Task.Run(() =>
            {
                var _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyDGQe6UI9b-y4NDGUO_FoOudQL7UnpxogA",
                    ApplicationName = "Kingdom Lifestyle Ministries"//this.GetType().ToString()
                });

                string nextpagetoken = " ";

                var searchListRequest = _youtubeService.VideoCategories.List("snippet");
                searchListRequest.RegionCode = "ZA";


                // Call the search.list method to retrieve results matching the specified query term.
                VideoCategoryListResponse categoryListResponse = searchListRequest.Execute();

                nextpagetoken = categoryListResponse.NextPageToken;


                return categoryListResponse.Items;

            });
        }

        public async Task UploadVideoToChannelAsync(VideoAddEditModel videoFile)
        {

            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows an application to upload files to the
                    // authenticated user's YouTube channel, but doesn't allow other types of access.
                    new[] { YouTubeService.Scope.YoutubeUpload },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });


            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = videoFile.Title;
            video.Snippet.Description = videoFile.Description;
            video.Snippet.Tags = videoFile.Tags.Split(',');
            video.Snippet.CategoryId = videoFile.SelectedCategory.Id; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "public"; // or "private" or "public"
            var filePath = videoFile.VideoUpload.FileName; // Replace with path to actual movie file.

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                await videosInsertRequest.UploadAsync();
            }

        }

        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    //Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    break;

                case UploadStatus.Failed:
                    //Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                    break;
            }
        }

        void videosInsertRequest_ResponseReceived(Video video)
        {
            //Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
        }

        #region Create        

        /// <summary>
        /// The method used to get and setup the correct video view
        /// </summary>
        /// <returns>The video create view</returns>
        public async Task<IActionResult> Create()
        {
            var model = new VideoAddEditModel();
            model.Categories = new SelectList(await GetVideosCategoriesFromChannelAsync("UCh4ifF5QzB0OtO3NpBjMTjA"), "Id", "Snippet.Title");
            return PartialView("/Areas/Gallery/Views/Video/_Create.cshtml", model);
        }

        /// <summary>
        /// The method that posts the updated video to the server
        /// </summary>
        /// <param name="model">The video model used for the update</param>
        /// <returns>The updated video</returns>
        [HttpPost]
        public ActionResult Create(VideoAddEditModel model)
        {
            if (ModelState.IsValid)
            {
                //var video = await _fileFactory.UploadVideoAndSaveToDbAsync<T>(model.VideoUpload, model.Video.Id, "videos/uploads");
                //if (video == null)
                //{
                //    video = new Video<T>()
                //    {
                //        Name = model.Video.Name,
                //        IFrameString = model.Video.IFrameString,
                //        Description = model.Video.Description
                //    };
                //}
                //else
                //{
                //    video.Name = model.Video.Name;
                //    video.IFrameString = model.Video.IFrameString;
                //    video.Description = model.Video.Description;
                //}

                //await _service.AddAsync(video);
                return RedirectToAction("List");
            }

            return View(model);
        }

        #endregion

        #region Edit

        /// <summary>
        /// The method used to get the edit video view
        /// </summary>
        /// <param name="id">The id of the video to be updated</param>
        /// <returns>The edit video view with the relevant video</returns>
        public async Task<IActionResult> Edit(string id)
        {
            //// Check to see if id is populated
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var album = await _service.GetAsync(id);

            //if (album == null)
            //{
            //    return NotFound();
            //}

            //var model = new VideoAddEditModel()
            //{
            //    Video = album
            //};

            return View();
        }

        /// <summary>
        /// The method used to post to the update video to the server
        /// </summary>
        /// <param name="model">The model that the video is being updated from</param>
        /// <returns>The video list view</returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VideoAddEditModel model)
        {
            //var video = await _service.GetAsync(model.Id);

            if (ModelState.IsValid)
            {
                //if (model.VideoUpload != null)
                //{
                //    if (video != null)
                //    {
                //        _fileFactory.DeleteFile(video.FolderPath, video.FileName);
                //        await _service.DeleteAsync(video);
                //    }

                //    var ff = await _fileFactory.UploadVideoAndSaveToDbAsync<Video>(model.VideoUpload, model.Video.Id, "videos/uploads/blog");
                //    await _service.AddAsync(video);
                //}
                //else
                //{
                //    video.Name = model.Video.Name;
                //    video.IFrameString = model.Video.IFrameString;
                //    video.Description = model.Video.Description;
                //}

                //   await _service.UpdateAsync(video);

                // Redirect to the index page
                return RedirectToAction(nameof(List));

            }
            return View(model);
        }

        #endregion

        #region Delete 

        //public async Task<ActionResult> Delete(string id)
        //{
        //    var entity = await _service.GetAsync(id);

        //    var model = new ModalModel()
        //    {
        //        HeaderString = "Are you sure you want to delete video ? " +
        //                       $"<br/> with id {entity.Id}",
        //        ControllerUrl = "/Gallery/Video/Delete",
        //        EntityId = entity.Id
        //    };

        //    return PartialView("Modals/_DeleteModal", model);
        //}

        //[HttpPost, ActionName("Delete")]

        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    await _service.DeleteAsync(id);
        //    // Get a list of all the blog sub-categories in json format
        //    var y = Json(true);
        //    // Return the Json
        //    return y;
        //}

        #endregion
    }
}