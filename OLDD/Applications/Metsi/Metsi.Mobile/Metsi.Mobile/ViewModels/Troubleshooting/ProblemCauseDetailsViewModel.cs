using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Grouping.Api.Models;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Base.Models;
using Iqt.Web.Exceptions;
using Metsi.Mobile.Models.Troubleshooting;
using Metsi.Mobile.ViewModels.Application;
using Metsi.Mobile.ViewModels.Authentication;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.ViewModels.Troubleshooting
{
    /// <summary>
    /// ViewModel for Problem Cause Details View.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ProblemCauseDetailsViewModel : BaseViewModel
    {
       private readonly IApplicationConfiguration _applicationConfiguration;
       private readonly HttpClient _client;

       private string _id;
       private string _parentId;
        private string productDescription;
        private string productVersion;
        private string productIcon;
        private string cardsTopImage;

        private ObservableCollection<CorrectiveActionsModel> _reviews;

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:Metsi.Mobile.ViewModels.AboutUs.AboutUsViewModel"/> class.
        /// </summary>
        public ProblemCauseDetailsViewModel(IHttpClientFactory httpClientFactory,
            IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = httpClientFactory.CreateClient();

            productIcon = App.BaseImageUrl + "Icon.png";
            productVersion = "1.0";
            cardsTopImage = App.BaseImageUrl + "Mask.png";

            BackButtonCommand = new Command(BackButtonClicked);
            MessagesButtonCommand = new Command(MessagesButtonClicked);
            SettingsButtonCommand = new Command(SettingsButtonClicked);
            ItemSelectedCommand = new Command(ItemSelected);
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
                var response = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/causes/" + navigationData);

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

                CauseResultModel result = await Task.Run(() => JsonConvert.DeserializeObject<CauseResultModel>(serialized));

                _id = result.Id;
                ParentId = result.ParentId;
                ProductDescription = result.Content.HtmlToPlainText();

                var response2 = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/correctiveactions?causeId=" + navigationData);

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

                PagedResult<CorrectiveActionResultModel> result2 = await Task.Run(() => JsonConvert.DeserializeObject<PagedResult<CorrectiveActionResultModel>>(serialized2));

                Reviews = new ObservableCollection<CorrectiveActionsModel>();
                foreach (var fff in result2.Results)
                {
                    Reviews.Add(new CorrectiveActionsModel(fff.Id, fff.ProblemContent.HtmlToPlainText(), fff.ParentId));
                }

                RaisePropertyChanged(() => Reviews);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Properties

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string ParentId
        {
            get => _parentId;
            set => SetProperty(ref _parentId, value);
        }

        /// <summary>
        /// Gets or sets the top image source of the About us with cards view.
        /// </summary>
        /// <value>Image source location.</value>
        public string CardsTopImage
        {
            get
            {
                return this.cardsTopImage;
            }

            set
            {
                this.cardsTopImage = value;
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
                return this.productDescription;
            }

            set
            {
                this.productDescription = value;
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
                return this.productIcon;
            }

            set
            {
                this.productIcon = value;
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
                return this.productVersion;
            }

            set
            {
                this.productVersion = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the article reviews
        /// </summary>
        public ObservableCollection<CorrectiveActionsModel> Reviews
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

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void BackButtonClicked(object obj)
        {
            await NavigationService.NavigateToAsync<ProblemDetailsViewModel>(ParentId);
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
        /// Invoked when an item is selected.
        /// </summary>
        private async void ItemSelected(object selectedItem)
        {
            var args = selectedItem as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            var model = args.ItemData as CorrectiveActionsModel;

            await NavigationService.NavigateToAsync<CorrectiveActionDetailsViewModel>(model.Id);
        }

        #endregion
    }
}
