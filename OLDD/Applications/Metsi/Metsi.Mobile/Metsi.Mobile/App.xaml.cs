using System.Threading.Tasks;
using Metsi.Mobile.Services.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Metsi.Mobile
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ0NTQ5QDMxMzgyZTMzMmUzMElLUFRaMEVzMUx3Qy9EVFlxRWU4SWI0UUhySkt1ais3ek5sdTFGbG0zQm89");

            InitializeComponent();

            Startup.Init();
            InitNavigation();

            //App.Current.MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /// <summary>
        /// Initializes navigation
        /// </summary>
        private Task InitNavigation()
        {
            var navigationService = Startup.ServiceProvider.GetService<INavigationService>();
            return navigationService.InitializeAsync();
        }
    }
}
