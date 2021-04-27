using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Grouping.Api.Models;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Metsi.Mobile.Models;
using Metsi.Mobile.Models.Troubleshooting;
using Metsi.Mobile.Services.Settings;
using Metsi.Mobile.ViewModels.Application;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.ViewModels.Troubleshooting
{
    /// <summary>
    /// ViewModel for Article parallax page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ProblemCategoryDetailsViewModel : BaseViewModel
    {
        private const string CategoryImageBaseUrl = "http://admin.metsi.co.za/images/uploads/Category`1/covers/";
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly HttpClient _client;

        private readonly ISettingsService _settingsService;

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        private string _id;
        private string _articleName;
        private string _articleImage;
        private string _articleParallaxHeaderImage;
        private string _articleSubImage;
        private string _articleAuthor;
        private string _articleDate;
        private string _articleContent;
        private string _articleReadingTime;
        private string _subTitle1;
        private string _subTitle2;

        private ObservableCollection<ProblemCategoryModel> _subCategories;
        private ObservableCollection<ProblemModel> _problems;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemCategoriesIndexViewModel" /> class
        /// </summary>
        public ProblemCategoryDetailsViewModel(ISettingsService settingsService, IHttpClientFactory httpClientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _settingsService = settingsService;
            _applicationConfiguration = applicationConfiguration;
            _client = httpClientFactory.CreateClient();

            ItemSelectedCommand = new Command(this.ItemSelected);
            ProblemTappedCommand = new Command(this.ProblemSelected);

            ShareButtonCommand = new Command(this.ShareButtonClicked);
            BackButtonCommand = new Command(this.BackButtonClicked);
            BookmarkCommand = new Command(this.BookmarkButtonClicked);
            RelatedFeaturesCommand = new Command(this.RelatedFeaturesItemClicked);
            AddNewCommentCommand = new Command(this.CommentButtonClicked);
            LoadMoreCommand = new Command(this.LoadMoreClicked);
            MessagesTappedCommand = new Command(MessagesTapped);
            SettingsTappedCommand = new Command(SettingsTapped);
        }

        /// <summary>
        /// The initialization override of the viewmodel
        /// </summary>
        /// <param name="navigationData">The navigation data</param>
        /// <returns></returns>
        public override async Task InitializeAsync(object navigationData)
        {
            
            try
            {
                var response = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/problemcategories/" + (string)navigationData);

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.Forbidden ||
                        response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                string serialized = await response.Content.ReadAsStringAsync();

                CategoryResultModel result = await Task.Run(() => JsonConvert.DeserializeObject<CategoryResultModel>(serialized));

                var iii = HttpUtility.UrlDecode(result.ImageUrl.Replace("\\", "/"));

                Id = result.Id;
                ArticleName = result.Name;
                ArticleParallaxHeaderImage = iii;
                ArticleSubImage = App.BaseImageUrl + "BlogDetail.png";
                ArticleContent = Regex.Replace(result.Description, @"\t|\n|\r", "").HtmlToPlainText().TruncateLongString(100); 
                SubTitle1 = "DESCRIPTION";
                SubTitle2 = "SUB CATEGORIES";
            var response2 = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/problemcategories/subcategories?parentId=" + Id);

            if (!response2.IsSuccessStatusCode)
            {
                var content = await response2.Content.ReadAsStringAsync();

                if (response2.StatusCode == HttpStatusCode.Forbidden ||
                    response2.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestExceptionEx(response2.StatusCode, content);
            }

            string serialized2 = await response2.Content.ReadAsStringAsync();

            PagedResult<CategoryResultModel> result2 = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<CategoryResultModel>>(serialized2));

            SubCategories = new ObservableCollection<ProblemCategoryModel>();
            foreach (var r in result2.Results)
            {
                var iiii = HttpUtility.UrlDecode(r.ImageUrl.Replace("\\", "/"));

                SubCategories.Add(new ProblemCategoryModel()
                {
                    Id = r.Id,
                    ImagePath = iiii,
                    Name = r.Name.TruncateLongString(25),
                    Description = r.Description.TruncateLongString(80)
                });
            }

            var response3 = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/problems/categoryproblems?categoryId=" + Id);

            if (!response3.IsSuccessStatusCode)
            {
                var content = await response3.Content.ReadAsStringAsync();

                if (response3.StatusCode == HttpStatusCode.Forbidden ||
                    response3.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestExceptionEx(response3.StatusCode, content);
            }

            string serialized3 = await response3.Content.ReadAsStringAsync();

            PagedResult<ProblemResultModel> result3 = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<ProblemResultModel>>(serialized3));

            Problems = new ObservableCollection<ProblemModel>();
            foreach (var rr in result3.Results)
            {
                Problems.Add(new ProblemModel()
                {
                    Id = rr.Id,
                    ProblemContent = rr.ProblemContent.HtmlToPlainText(),
                    CausesCount = rr.CausesCount,
                    CorrectiveActionsCount = rr.CorrectiveActionsCount
                });
            }

            this.ArticleReadingTime = $"{Problems.Count} Problems";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await base.InitializeAsync(navigationData);

            RaisePropertyChanged(() => SubCategories);
            RaisePropertyChanged(() => IsSubCategoriesVisible);
            RaisePropertyChanged(() => Problems);
            RaisePropertyChanged(() => IsProblemsVisible);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// The identity of the featured Category
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        public string Title
        {
            get
            {
                return this._articleName.TruncateLongString(35);
            }
        }

        /// <summary>
        /// Gets or sets the article name
        /// </summary>
        public string ArticleName
        {
            get
            {
                return this._articleName;
            }

            set
            {
                if (this._articleName != value)
                {
                    this._articleName = value;
                    OnPropertyChanged();
                    OnPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Gets or sets the article image
        /// </summary>
        public string ArticleImage
        {
            get
            {
                return this._articleImage;
            }

            set
            {
                if (this._articleImage != value)
                {
                    this._articleImage = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article image
        /// </summary>
        public string ArticleParallaxHeaderImage
        {
            get
            {
                return this._articleParallaxHeaderImage;
            }

            set
            {
                if (this._articleParallaxHeaderImage != value)
                {
                    this._articleParallaxHeaderImage = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article sub image
        /// </summary>
        public string ArticleSubImage
        {
            get
            {
                return this._articleSubImage;
            }

            set
            {
                if (this._articleSubImage != value)
                {
                    this._articleSubImage = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the articleAuthor
        /// </summary>
        public string ArticleAuthor
        {
            get
            {
                return this._articleAuthor;
            }

            set
            {
                if (this._articleAuthor != value)
                {
                    this._articleAuthor = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article reading time
        /// </summary>
        public string ArticleReadingTime
        {
            get
            {
                return this._articleReadingTime;
            }

            set
            {
                if (this._articleReadingTime != value)
                {
                    this._articleReadingTime = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article date
        /// </summary>
        public string ArticleDate
        {
            get
            {
                return this._articleDate;
            }

            set
            {
                if (this._articleDate != value)
                {
                    this._articleDate = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the article content
        /// </summary>
        public string ArticleContent
        {
            get
            {
                return this._articleContent;
            }

            set
            {
                if (this._articleContent != value)
                {
                    this._articleContent = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with the list view which displays the articles related stories items.
        /// </summary>
        public ObservableCollection<ProblemCategoryModel> SubCategories
        {
            get
            {
                return this._subCategories;
            }

            set
            {
                if (this._subCategories == value)
                {
                    return;
                }

                this._subCategories = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("IsSubCategoriesVisible");
            }
        }

        public bool IsSubCategoriesVisible { get { return SubCategories!= null && SubCategories.Count > 0; } }

        /// <summary>
        /// Gets or sets the article reviews
        /// </summary>
        public ObservableCollection<ProblemModel> Problems
        {
            get
            {
                return this._problems;
            }

            set
            {
                if (this._problems == value)
                {
                    return;
                }

                this._problems = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(IsProblemsVisible));
            }
        }

        public bool IsProblemsVisible { get { return Problems != null && Problems.Count > 0; } }

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        public string SubTitle1
        {
            get
            {
                return this._subTitle1;
            }

            set
            {
                if (this._subTitle1 == value)
                {
                    return;
                }

                this._subTitle1 = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the article sub title
        /// </summary>
        public string SubTitle2
        {
            get
            {
                return this._subTitle2;
            }

            set
            {
                if (this._subTitle2 == value)
                {
                    return;
                }

                this._subTitle2 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand MessagesTappedCommand { get; set; }

        public ICommand SettingsTappedCommand { get; set; }

        /// <summary>
    /// Gets or sets the command that will be executed when an item is selected.
    /// </summary>
        public Command ProblemTappedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command ShareButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the book mark button is clicked.
        /// </summary>
        public Command BookmarkCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the related features item is clicked.
        /// </summary>
        public Command RelatedFeaturesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Comment button is clicked.
        /// </summary>
        public Command AddNewCommentCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the Show All button is clicked.
        /// </summary>
        public Command LoadMoreCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ShareButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async void BackButtonClicked(object obj)
        {
            await NavigationService.NavigateToAsync<ProblemCategoryListViewModel>();
        }

        /// <summary>
        /// Invoked when the related features item clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void RelatedFeaturesItemClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the bookmark button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BookmarkButtonClicked(object obj)
        {
            //if (obj != null && (obj is Category<Problem>))
            //{
            //    (obj as Category<Problem>).IsBookmarked = (obj as Category<Problem>).IsBookmarked ? false : true;
            //}
            //else
            //{
            //    var button = obj as SfButton;
            //    if (button != null)
            //    {
            //        button.Text = (button.Text == "\ue72f") ? "\ue734" : "\ue72f";
            //    }
            //}
        }

        /// <summary>
        /// Invoked when Comment button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void CommentButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when Load more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void LoadMoreClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void ItemSelected(object selectedItem)
        {
            var args = selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var model = args.ItemData as ProblemCategoryModel;

            await NavigationService.NavigateToAsync<ProblemCategoryDetailsViewModel>(model.Id);
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void ProblemSelected(object selectedItem)
        {
            var args = selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var model = args.ItemData as ProblemModel;

            await NavigationService.NavigateToAsync<ProblemDetailsViewModel>(model.Id);
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void SettingsTapped(object selectedItem)
        {
            await NavigationService.NavigateToAsync<CommingSoonViewModel>();
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void MessagesTapped(object selectedItem)
        {
            await NavigationService.NavigateToAsync<CommingSoonViewModel>();
        }

        #endregion
    }
}
