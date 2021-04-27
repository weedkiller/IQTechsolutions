using System.Threading.Tasks;
using Metsi.Mobile.ViewModels;
using Metsi.Mobile.ViewModels.Base;

namespace Metsi.Mobile.Services.Navigation
{
    public interface INavigationService
    {
		BaseViewModel PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}