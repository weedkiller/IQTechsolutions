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
    public partial class CausesListTemplate : Grid
    {
        public CausesListTemplate()
        {
            InitializeComponent();
        }
    }
}