using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Grouping.Api.Models;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Metsi.Mobile.Models;
using Metsi.Mobile.Models.Troubleshooting;
using Metsi.Mobile.ViewModels.Application;
using Metsi.Mobile.ViewModels.Authentication;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.ViewModels.Troubleshooting
{
    /// <summary>
    /// ViewModel for article list page.
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class ProblemCategoryListViewModel : BaseViewModel
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly HttpClient _client;

        private ObservableCollection<ProblemCategoryModel> featuredCategories;
        private ObservableCollection<ProblemCategoryModel> troubleShootingSections;

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="service">The injectec category REST service</param>
        public ProblemCategoryListViewModel(IHttpClientFactory httpClientFactory,
            IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = httpClientFactory.CreateClient();

            BackButtonCommand = new Command(this.BackButtonClicked);
            MessagesButtonCommand = new Command(this.MessagesButtonClicked);
            SettingsButtonCommand = new Command(this.SettingsButtonClicked);
            FeatureCategoriesCommand = new Command(this.FeatureCategoriesClicked);
            ItemSelectedCommand = new Command(this.ItemSelected);
        }

        /// <summary>
        /// Initializes a new instance for the <see cref="ProblemCategoryListViewModel" /> class.
        /// </summary>
        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                var response =
                    await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/problemcategories");

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

                var serialized = await response.Content.ReadAsStringAsync();
                PagedResult<CategoryResultModel> result = await Task.Run(() =>
                    JsonConvert.DeserializeObject<PagedResult<CategoryResultModel>>(serialized));

                FeaturedCategories = new ObservableCollection<ProblemCategoryModel>();
                foreach (var item in result.Results.Take(5))
                {
                    var iii = HttpUtility.UrlDecode(item.ImageUrl.Replace("\\", "/"));
                    FeaturedCategories.Add(new ProblemCategoryModel()
                    {
                        Id = item.Id,
                        ImagePath = iii,
                        Name = item.Name.TruncateLongString(35),
                        Description = item.Description.TruncateLongString(50),
                        SubCategoryCount = item.ChildCount,
                        ProblemCount = item.EntityCount
                    });
                }

                TroubleShootingSections = new ObservableCollection<ProblemCategoryModel>();
                foreach (var item in result.Results)
                {
                    var iii = HttpUtility.UrlDecode(item.ImageUrl.Replace("\\", "/"));
                    TroubleShootingSections.Add(new ProblemCategoryModel()
                    {
                        Id = item.Id,
                        ImagePath = iii,
                        Name = item.Name.TruncateLongString(25),
                        Description = item.Description.TruncateLongString(80),
                        SubCategoryCount = item.ChildCount,
                        ProblemCount = item.EntityCount
                    });
                }

                OnPropertyChanged("FeaturedCategories");
                OnPropertyChanged("TroubleShootingSections");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await base.InitializeAsync(navigationData);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the property that has been bound with the rotator view, which displays the featured category items.
        /// </summary>
        public ObservableCollection<ProblemCategoryModel> FeaturedCategories
        {
            get { return featuredCategories; }

            set
            {
                if (featuredCategories == value)
                {
                    return;
                }

                featuredCategories = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with the list view, which displays the Trouble Shooting items.
        /// </summary>
        public ObservableCollection<ProblemCategoryModel> TroubleShootingSections
        {
            get { return troubleShootingSections; }

            set
            {
                if (troubleShootingSections == value)
                {
                    return;
                }

                troubleShootingSections = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the messages button is clicked.
        /// </summary>
        public Command MessagesButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when the settings button is clicked.
        /// </summary>
        public Command SettingsButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will executed when the feature stories item is clicked.
        /// </summary>
        public Command FeatureCategoriesCommand { get; set; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void BackButtonClicked(object obj)
        {
            await NavigationService.NavigateToAsync<MainViewModel>();
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void SettingsButtonClicked(object obj)
        {
            await NavigationService.NavigateToAsync<LoginViewModel>();
        }

        /// <summary>
        /// Invoked when the messages button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void MessagesButtonClicked(object obj)
        {
            await NavigationService.NavigateToAsync<LoginViewModel>();
        }

        /// <summary>
        /// Invoked when the the feature stories item is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private async void FeatureCategoriesClicked(object obj)
        {
            await NavigationService.NavigateToAsync<ProblemCategoryDetailsViewModel>(((ProblemCategoryModel) obj).Id);
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void ItemSelected(object obj)
        {

            await NavigationService.NavigateToAsync<ProblemCategoryDetailsViewModel>(((ProblemCategoryModel) obj).Id);
        }

        #endregion
    }
}
