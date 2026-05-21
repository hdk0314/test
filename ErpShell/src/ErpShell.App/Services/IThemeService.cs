namespace ErpShell.App.Services;

public enum AppTheme { Light, Dark }

public interface IThemeService
{
    AppTheme Current { get; }
    event Action? ThemeChanged;
    void Apply(AppTheme theme);
    void Toggle();
}
