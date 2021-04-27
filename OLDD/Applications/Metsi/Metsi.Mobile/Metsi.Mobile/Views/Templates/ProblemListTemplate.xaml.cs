using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Templates
{
    /// <summary>
    /// Navigation list template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProblemListTemplate : Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemListTemplate"/> class.
        /// </summary>
        public ProblemListTemplate()
        {
            InitializeComponent();
        }
    }
}