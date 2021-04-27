using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Troubleshooting
{
    /// <summary>
    /// Page to list out article items.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemCategoryListView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemCategoryListView" /> class.
        /// </summary>
        public ProblemCategoryListView()
        {
            InitializeComponent();
        }
    }
}