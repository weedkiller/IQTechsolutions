using FeawThings.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FeawThings.Mobile.Views
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