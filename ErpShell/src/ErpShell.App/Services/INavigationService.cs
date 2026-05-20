using ErpShell.App.ViewModels;

namespace ErpShell.App.Services;

public interface INavigationService
{
    ViewModelBase? Current { get; }
    event Action? CurrentChanged;
    void NavigateTo(string key);
}
