using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Application
{
    /// <summary>
    /// Page to show the setting.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingPage" /> class.
        /// </summary>
        public SettingView()
        {
            InitializeComponent();
        }
    }
}