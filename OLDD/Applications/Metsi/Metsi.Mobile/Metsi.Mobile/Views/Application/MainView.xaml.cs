using System;
using System.Globalization;
using System.Reflection;
using Metsi.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Metsi.Mobile.Views.Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainViewMasterMenuItem;
            if (item == null)
                return;


            var page = CreatePage(item.TargetType);
            page.Title = item.Title;

            var navigationPage = App.Current.MainPage as CustomNavigationView;
            if (navigationPage != null)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                Detail = new CustomNavigationView(page);
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(null);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            try
            {
                Page page = Activator.CreateInstance(pageType) as Page;
                return page;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
    }
}