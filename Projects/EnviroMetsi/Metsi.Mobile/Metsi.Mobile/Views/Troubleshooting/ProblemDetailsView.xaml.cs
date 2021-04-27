using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Troubleshooting
{
    /// <summary>
    /// Problem Detail View.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemDetailsView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemDetailsView"/> class.
        /// </summary>
        public ProblemDetailsView()
        {
            InitializeComponent();
        }
    }
}