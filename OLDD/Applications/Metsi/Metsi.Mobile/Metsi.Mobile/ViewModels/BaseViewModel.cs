using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Metsi.Mobile.Base;
using Xamarin.Forms;

using Metsi.Mobile.Models;
using Metsi.Mobile.Services;
using Metsi.Mobile.Services.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace Metsi.Mobile.ViewModels
{
    public class BaseViewModel : ExtendedBindableObject
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        protected readonly INavigationService NavigationService;

        bool isBusy = false;

        public BaseViewModel()
        {
            NavigationService = Startup.ServiceProvider.GetService<INavigationService>();
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            NotifyPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
