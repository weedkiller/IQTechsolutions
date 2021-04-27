using System;
using System.Collections.Generic;
using System.Linq;
using Iqt.Base.Models;

namespace Iqt.Base.Extensions
{
    /// <summary>
    /// Extensions used to page a query or a list
    /// </summary>
    public static class PagingExtensions
    {
        /// <summary>
        /// The extension method that gets the paged results
        /// </summary>
        /// <typeparam name="T">The entity that is featured in the paged list</typeparam>
        /// <param name="query">The query that needs to be paged</param>
        /// <param name="page">The active page</param>
        /// <param name="pageSize">The size of the page</param>
        /// <returns>The paged result of the query</returns>
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        /// <summary>
        /// The extension method that gets the paged results
        /// </summary>
        /// <typeparam name="T">The entity that is featured in the paged list</typeparam>
        /// <param name="query">The query that needs to be paged</param>
        /// <param name="page">The active page</param>
        /// <param name="pageSize">The size of the page</param>
        /// <returns>The paged result of the query</returns>
        public static PagedResult<T> GetPaged<T>(this IEnumerable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
