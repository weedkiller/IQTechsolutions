using IQTechSolutions.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IQTechSolutions.Mobile.Views
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