using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErpShell.App.Models;
using ErpShell.App.Services;

namespace ErpShell.App.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _navigation;
    private readonly IThemeService _theme;

    public MainWindowViewModel(INavigationService navigation, IThemeService theme)
    {
        _navigation = navigation;
        _theme = theme;

        NavItems = new ObservableCollection<NavigationItem>
        {
            new("dashboard",  "대시보드",   "IconDashboard",  "Overview"),
            new("sales",      "영업관리",   "IconSales",      "Operations"),
            new("purchases",  "구매관리",   "IconPurchase",   "Operations"),
            new("inventory",  "재고관리",   "IconInventory",  "Operations"),
            new("hr",         "인사관리",   "IconHR",         "Management"),
            new("accounting", "회계관리",   "IconAccounting", "Management"),
            new("reports",    "리포트",     "IconReports",    "Management"),
            new("settings",   "설정",       "IconSettings",   "System"),
        };

        _navigation.CurrentChanged += OnNavigationChanged;
        _theme.ThemeChanged += () => OnPropertyChanged(nameof(IsDarkTheme));

        SelectedNav = NavItems[0];
    }

    public ObservableCollection<NavigationItem> NavItems { get; }

    [ObservableProperty]
    private NavigationItem? _selectedNav;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _userName = "김도경";

    [ObservableProperty]
    private string _userRole = "관리자";

    [ObservableProperty]
    private int _notificationCount = 3;

    public ViewModelBase? Current => _navigation.Current;

    public bool IsDarkTheme => _theme.Current == AppTheme.Dark;

    partial void OnSelectedNavChanged(NavigationItem? value)
    {
        if (value is not null) _navigation.NavigateTo(value.Key);
    }

    private void OnNavigationChanged() => OnPropertyChanged(nameof(Current));

    [RelayCommand]
    private void ToggleTheme() => _theme.Toggle();
}
