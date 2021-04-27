using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedback.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Core.Context.Services
{
    /// <summary>
    /// The news feed database context
    /// </summary>
    public class NewsFeedContext 
    {
        private readonly DbContext _context;

        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="context">The injected database context</param>
        public NewsFeedContext(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all feeds from the database
        /// </summary>
        /// <param name="privateFeed">flag to indicate whether private feeds should be included in the collection</param>
        /// <returns></returns>
        public IEnumerable<NewsFeed> GetAllFeeds(bool privateFeed = false)
        {
            var collection = _context.Set<NewsFeed>()
                .Include(c => c.Comments).ThenInclude(c => c.Comments).ThenInclude(c => c.FeedFeelings)
                //.Include(c => c.Files)
                .Include(c => c.AudioFiles)
                .Include(c => c.Images)
                .Include(c => c.Videos)
                .Include(c => c.FeedFeelings);

            if (privateFeed)
                return collection.Where(c => c.Private);
            return collection;
        }

        /// <summary>
        /// Adds a new feed to the database
        /// </summary>
        /// <param name="newsFeed">The newsFeed that should be added</param>
        /// <returns>The newsFeed that was added as a task</returns>
        public async Task<NewsFeed> AddNewsFeedAsync(NewsFeed newsFeed)
        {
            try
            {
                _context.Set<NewsFeed>().Add(newsFeed);
                await _context.SaveChangesAsync();
                return newsFeed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        #endregion
    }
}
