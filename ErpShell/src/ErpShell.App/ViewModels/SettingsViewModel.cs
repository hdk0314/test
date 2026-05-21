using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErpShell.App.Services;

namespace ErpShell.App.ViewModels;

public sealed partial class SettingsViewModel : ViewModelBase
{
    private readonly IThemeService _theme;

    public SettingsViewModel(IThemeService theme)
    {
        _theme = theme;
        Title = "설정";
        Subtitle = "테마, 계정, 알림 등을 관리합니다.";

        _theme.ThemeChanged += () => OnPropertyChanged(nameof(IsDark));
    }

    public bool IsDark => _theme.Current == AppTheme.Dark;

    [ObservableProperty]
    private string _companyName = "(주)에르피쉘";

    [ObservableProperty]
    private string _email = "kdg6146@gmail.com";

    [ObservableProperty]
    private bool _emailNotifications = true;

    [ObservableProperty]
    private bool _desktopNotifications = false;

    [RelayCommand]
    private void ToggleTheme() => _theme.Toggle();
}
