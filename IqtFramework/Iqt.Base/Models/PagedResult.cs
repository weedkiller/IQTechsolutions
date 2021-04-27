using System;
using System.Collections.Generic;
using System.Text;

namespace Iqt.Base.Models
{
    /// <summary>
    /// The paged result of any query
    /// </summary>
    /// <typeparam name="T">The entity or model featured by the query</typeparam>
    public class PagedResult<T>
    {
        #region Default Contstructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PagedResult()
        {
            Results = new List<T>();
        }

        #endregion

        /// <summary>
        /// The active page of the paged result
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The total count of pages in the paged result
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// The size of a page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The Amount of rows the page contains
        /// only really relevant on the last page
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// The order the results are sorted in
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// The count of the first row on the page in regards to the total list
        /// </summary>
        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;

        /// <summary>
        /// The count of the last row on the page in regards to the total list
        /// </summary>
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);

        

        /// <summary>
        /// The paged Results
        /// </summary>
        public IList<T> Results { get; set; }
    }
}
