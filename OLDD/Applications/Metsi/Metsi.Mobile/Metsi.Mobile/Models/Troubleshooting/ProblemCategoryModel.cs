using Metsi.Mobile.ViewModels;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.Models.Troubleshooting
{
    /// <summary>
    /// Model for Article templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ProblemCategoryModel : BaseViewModel
    {
        #region Fields

        private string _imagePath;

        #endregion

        #region Public Properties

        /// <summary>
        /// The identity of the featured category
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the article image path.
        /// </summary>
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                NotifyPropertyChanged();
            }

        }

        /// <summary>
        /// Gets or sets the article name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the article author name.
        /// </summary>
        public string Author { get; set; }


        /// <summary>
        /// Gets or sets the article publish date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the article read time.
        /// </summary>
        public string AverageReadingTime { get; set; }

        /// <summary>
        /// Gets or sets the article description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the bookmarked count.
        /// </summary>
        public string CountLabel
        {
            get
            {
                if (SubCategoryCount > 0)
                {
                    return "Sub-Categories";
                }
                else
                {
                    return "Problems";
                }
            }
        }

        /// <summary>
        /// Gets or sets the bookmarked count.
        /// </summary>
        public int SubCategoryCount { get; set; }

        /// <summary>
        /// Gets or sets the favourite count.
        /// </summary>
        public int ProblemCount { get; set; }

        /// <summary>
        /// Gets or sets the shared count.
        /// </summary>
        public int SharedCount { get; set; }

        #endregion
    }
}