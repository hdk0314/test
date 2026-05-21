using CommunityToolkit.Mvvm.ComponentModel;

namespace ErpShell.App.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _subtitle = string.Empty;
}
