using Maui7.Services.Navigation;
using Maui7.ViewModels;

namespace Maui7;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        InitApp();
        InitNavigation();
        

    }
    private void InitApp()
    {
        
        ViewModelLocator.RegisterDependencies(false);
    }

    private Task InitNavigation()
    {
        var navigationService = ViewModelLocator.Resolve<INavigationService>();
        return navigationService.InitializeAsync();
    }
}
