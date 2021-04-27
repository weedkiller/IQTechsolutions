using System.ComponentModel;
using Xamarin.Forms;
using Metsi.Mobile.ViewModels;

namespace Metsi.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}