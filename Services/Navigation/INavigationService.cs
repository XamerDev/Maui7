using Maui7.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maui7.Services.Navigation
{
    public interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
        Task NavigateBackAsync();
    }
}
