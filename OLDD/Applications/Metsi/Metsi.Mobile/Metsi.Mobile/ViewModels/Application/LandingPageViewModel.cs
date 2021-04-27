using System.Collections.ObjectModel;
using Metsi.Mobile.Models.Application;
using Metsi.Mobile.ViewModels.Authentication;
using Metsi.Mobile.ViewModels.Chat;
using Metsi.Mobile.ViewModels.Troubleshooting;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace Metsi.Mobile.ViewModels.Application
{
    /// <summary>
    /// ViewModel of AboutUs templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LandingPageViewModel : BaseViewModel
    {
        private string _version;
        private string _title;
        private string _description;
        private string _icon;
        private string _cardsTopImage;

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="T:Metsi.Mobile.ViewModels.Application.AboutUsViewModel"/> class.
        /// </summary>
        public LandingPageViewModel()
        {
            this._version = "Alpha 1.0";
            _title = "Enviro Metsi";
            _description = "Enviro Metsi consists of a team of water care professionals who ensure the optimum performance of any treatment system. We are able to adapt current and innovative new technology to our clients' specific needs. Whether the process is for municipal services, other publicly employed use or industrial purposes, we will ensure that we provide the best possible solutions to every unique situation.";
            _icon = "http://www.metsi.co.za/images/mobile/waterdropIcon.png";
            CardsTopImage = "http://www.metsi.co.za/images/mobile/tapwater.jpg";

            this.NavigationalItems = new ObservableCollection<LandingPageNavigationItemModel>
            {
                new LandingPageNavigationItemModel()
                {
                    ItemName = "Troubleshooting",
                    Image = "http://training.metsi.co.za/images/Content/TroubleShooting.jpg",
                    Description = "Try our free troubleshooting section for assistance with solving most of your water and wastewater related issues."
                },
                new LandingPageNavigationItemModel()
                {
                    ItemName = "Short Courses",
                    Image = "http://training.metsi.co.za/images/Content/ExpertTeacher.jpg",
                    Description = "Only want to brush up on a specific skill? Subscrive to one of the Short Courses presented by one of our passionate industry experts."
                },
                new LandingPageNavigationItemModel()
                {
                    ItemName = "Calculations",
                    Image = "http://training.metsi.co.za/images/Content/Calculations.jpg",
                    Description = "Enviro Metsi offers you lifetime access to materials and results, obtained by subscribing to one of our awesome courses."
                },
                new LandingPageNavigationItemModel()
                {
                    ItemName = "Chat",
                    Image = "http://training.metsi.co.za/images/Content/Chat.jpg",
                    Description = "Talk to one of our experts or to each other on our live social platform. Socialise while studying!"
                }
            };

            this.ItemSelectedCommand = new Command(this.ItemSelected);
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
                return _cardsTopImage;
            }

            set
            {
                _cardsTopImage = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                this._title = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description of a product or a company.
        /// </summary>
        /// <value>The product description.</value>
        public string Description
        {
            get => _description;

            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the product icon.
        /// </summary>
        /// <value>The product icon.</value>
        public string Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                this._icon = value;
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
                return _version;
            }

            set
            {
                _version = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<LandingPageNavigationItemModel> NavigationalItems { get; }

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        private async void ItemSelected(object selectedItem)
        {
            var selected = (LandingPageNavigationItemModel) (((ItemTappedEventArgs) selectedItem).ItemData);

            switch (selected.ItemName)
            {
                case "Troubleshooting":
                    await NavigationService.NavigateToAsync<ProblemCategoryListViewModel>();
                    break;
                case "Short Courses":
                    await NavigationService.NavigateToAsync<LoginViewModel>(); ;
                    break;
                case "Calculations":
                    await NavigationService.NavigateToAsync<LoginViewModel>(); ;
                    break;
                case "Chat":
                    await NavigationService.NavigateToAsync<RecentChatViewModel>(); ;
                    break;
                default:
                    await NavigationService.NavigateToAsync<SomethingWentWrongViewModel>(); ;
                    break;
            }
        }

        #endregion
    }
}