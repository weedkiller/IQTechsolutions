using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Application
{
    /// <summary>
    /// Page to show the something went wrong
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SomethingWentWrongView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SomethingWentWrongView" /> class.
        /// </summary>
        public SomethingWentWrongView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    ErrorImage.IsVisible = false;
                }
            }
            else
            {
                ErrorImage.IsVisible = true;
            }
        }
    }
}