using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Troubleshooting
{
    /// <summary>
    /// Problem Cause Detail View.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemCauseDetailsView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemCauseDetailsView"/> class.
        /// </summary>
        public ProblemCauseDetailsView()
        {
            InitializeComponent();
        }
    }
}