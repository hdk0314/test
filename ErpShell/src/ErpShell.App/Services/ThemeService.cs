using System.Windows;

namespace ErpShell.App.Services;

public sealed class ThemeService : IThemeService
{
    private const string LightPath = "Themes/Brushes.Light.xaml";
    private const string DarkPath  = "Themes/Brushes.Dark.xaml";

    public AppTheme Current { get; private set; } = AppTheme.Light;
    public event Action? ThemeChanged;

    public void Apply(AppTheme theme)
    {
        var dictionaries = Application.Current.Resources.MergedDictionaries;
        var path = theme == AppTheme.Dark ? DarkPath : LightPath;

        var existing = dictionaries.FirstOrDefault(d =>
            d.Source is { } src &&
            (src.OriginalString.EndsWith("Brushes.Light.xaml", StringComparison.OrdinalIgnoreCase) ||
             src.OriginalString.EndsWith("Brushes.Dark.xaml",  StringComparison.OrdinalIgnoreCase)));

        var fresh = new ResourceDictionary
        {
            Source = new Uri(path, UriKind.Relative)
        };

        if (existing is null)
            dictionaries.Insert(0, fresh);
        else
            dictionaries[dictionaries.IndexOf(existing)] = fresh;

        Current = theme;
        ThemeChanged?.Invoke();
    }

    public void Toggle() => Apply(Current == AppTheme.Light ? AppTheme.Dark : AppTheme.Light);
}
