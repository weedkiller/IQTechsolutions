using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Metsi.Mobile.ViewModels.Application;
using Metsi.Mobile.ViewModels.Authentication;
using Metsi.Mobile.ViewModels.Chat;
using Metsi.Mobile.ViewModels.Faqs;
using Metsi.Mobile.ViewModels.Support;
using Metsi.Mobile.ViewModels.Troubleshooting;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewMaster : ContentPage
    {
        public ListView ListView;

        public MainViewMaster()
        {
            InitializeComponent();

            BindingContext = new MainViewMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainViewMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainViewMasterMenuItem> MenuItems { get; set; }

            public MainViewMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainViewMasterMenuItem>(new[]
                {
                    new MainViewMasterMenuItem { Id = 1, Title = "Troubleshooting", TargetType = typeof(ProblemCategoryListViewModel)},
                    new MainViewMasterMenuItem { Id = 4, Title = "FAQ's", TargetType = typeof(FAQViewModel) },
                    new MainViewMasterMenuItem { Id = 4, Title = "Help Me", TargetType = typeof(CommingSoonViewModel) },
                    new MainViewMasterMenuItem { Id = 4, Title = "Contact Us", TargetType = typeof(ContactUsViewModel) },
                    new MainViewMasterMenuItem { Id = 5, Title = "Login", TargetType = typeof(LoginViewModel) }
                });
            }

            #region INotifyPropertyChanged Implementation

            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }
    }
}