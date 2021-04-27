using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Grouping.Api.Models;
using Iqt.Base.Extensions;
using Iqt.Base.Interfaces;
using Iqt.Web.Exceptions;
using Metsi.Mobile.Models.Troubleshooting;
using Metsi.Mobile.ViewModels.Authentication;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.ViewModels.Troubleshooting
{
    /// <summary>
    /// ViewModel for Corrective Actions Details View.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CorrectiveActionDetailsViewModel : BaseViewModel
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly HttpClient _client;

        private string _id;
        private string _parentId;
        private string productDescription;
        private string productVersion;
        private string productIcon;
        private string cardsTopImage;

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:Metsi.Mobile.ViewModels.AboutUs.AboutUsViewModel"/> class.
        /// </summary>
        public CorrectiveActionDetailsViewModel(IHttpClientFactory httpClientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
            _client = httpClientFactory.CreateClient();

            this.productIcon = App.BaseImageUrl + "Icon.png";
            this.productVersion = "1.0";
            this.cardsTopImage = App.BaseImageUrl + "Mask.png";

            BackButtonCommand = new Command(BackButtonClicked);
            MessagesButtonCommand = new Command(MessagesButtonClicked);
            SettingsButtonCommand = new Command(SettingsButtonClicked);
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
                var response = await _client.GetAsync(_applicationConfiguration.BaseApiUrl + "/api/v1/correctiveactions/" + (string)navigationData);

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

                CorrectiveActionResultModel result = await Task.Run(() => JsonConvert.DeserializeObject<CorrectiveActionResultModel>(serialized));

                _id = result.Id;
                _parentId = result.ParentId;
                ProductDescription = result.ProblemContent.HtmlToPlainText();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await base.InitializeAsync(navigationData);
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
            await NavigationService.NavigateToAsync<ProblemCauseDetailsViewModel>(ParentId);
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

        #endregion
    }
}