using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Grouping.Api.Models;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Metsi.Mobile.Models.Troubleshooting;
using Metsi.Mobile.ViewModels.Application;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.ViewModels.Troubleshooting
{
    /// <summary>
    /// ViewModel for Problem Details View.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ProblemDetailsViewModel : BaseViewModel
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly HttpClient _client;

        private string _id;
        private string _productDescription;
        private string _productVersion;
        private string _productIcon;
        private string _cardsTopImage;

        private ObservableCollection<CauseModel> _reviews;

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:Metsi.Mobile.ViewModels.AboutUs.AboutUsViewModel"/> class.
        /// </summary>
        public ProblemDetailsViewModel(IApplicationConfiguration applicationConfiguration, IHttpClientFactory client)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = client.CreateClient();

            this._productIcon = App.BaseImageUrl + "Icon.png";
            this._productVersion = "1.0";
            this._cardsTopImage = App.BaseImageUrl + "Mask.png";

            this.ItemSelectedCommand = new Command(this.ItemSelected);
            MessagesTappedCommand = new Command(MessagesTapped);
            SettingsTappedCommand = new Command(SettingsTapped);
            BackButtonCommand = new Command(BackButtonTapped);
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
                var response = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/problems/" + (string)navigationData);

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

                ProblemResultModel problem = await Task.Run(() => JsonConvert.DeserializeObject<ProblemResultModel>(serialized));
                ProductDescription = problem.ProblemContent.HtmlToPlainText();
            
                var response2 = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/causes?problemId=" + navigationData);

                if (!response2.IsSuccessStatusCode)
                {
                    var content = await response2.Content.ReadAsStringAsync();

                    if (response.StatusCode == HttpStatusCode.Forbidden ||
                        response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ServiceAuthenticationException(content);
                    }

                    throw new HttpRequestExceptionEx(response.StatusCode, content);
                }

                string serialized2 = await response2.Content.ReadAsStringAsync();

                PagedResult<CauseResultModel> result = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<CauseResultModel>>(serialized2));

                Reviews = new ObservableCollection<CauseModel>();
                foreach (var item in result.Results)
                {
                    Reviews.Add(new CauseModel()
                    {
                        Id = item.Id,
                        ProblemContent = item.Content.HtmlToPlainText(),
                        CorrectiveActionsCount = item.CorrectiveActionsCount
                    });
                }
                NotifyPropertyChanged(nameof(Reviews));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the top image source of the About us with cards view.
        /// </summary>
        /// <value>Image source location.</value>
        public string CardsTopImage
        {
            get
            {
                return this._cardsTopImage;
            }

            set
            {
                this._cardsTopImage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        public string ProductDescription
        {
            get
            {
                return this._productDescription;
            }

            set
            {
                this._productDescription = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product icon.
        /// </summary>
        /// <value>The product icon.</value>
        public string ProductIcon
        {
            get
            {
                return this._productIcon;
            }

            set
            {
                this._productIcon = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product version.
        /// </summary>
        /// <value>The product version.</value>
        public string ProductVersion
        {
            get
            {
                return this._productVersion;
            }

            set
            {
                this._productVersion = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the article reviews
        /// </summary>
        public ObservableCollection<CauseModel> Reviews
        {
            get
            {
                return this._reviews;
            }

            set
            {
                if (this._reviews == value)
                {
                    return;
                }

                this._reviews = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        public ICommand MessagesTappedCommand { get; set; }

        public ICommand SettingsTappedCommand { get; set; }

        public ICommand BackButtonCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void ItemSelected(object selectedItem)
        {
            var args = selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var model = args.ItemData as CauseModel;

            await NavigationService.NavigateToAsync<ProblemCauseDetailsViewModel>(model.Id);
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

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void BackButtonTapped(object selectedItem)
        {
            await NavigationService.NavigateToAsync<ProblemCategoryListViewModel>();
        }

        #endregion
    }
}
