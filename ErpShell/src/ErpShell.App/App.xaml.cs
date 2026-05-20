using System.Windows;
using ErpShell.App.Services;
using ErpShell.App.ViewModels;
using ErpShell.App.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ErpShell.App;

public partial class App : Application
{
    public IServiceProvider Services { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Services = ConfigureServices();

        var window = Services.GetRequiredService<MainWindow>();
        window.DataContext = Services.GetRequiredService<MainWindowViewModel>();
        window.Show();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IThemeService, ThemeService>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddTransient<DashboardViewModel>();
        services.AddTransient<SalesViewModel>();
        services.AddTransient<PurchasesViewModel>();
        services.AddTransient<InventoryViewModel>();
        services.AddTransient<HrViewModel>();
        services.AddTransient<AccountingViewModel>();
        services.AddTransient<ReportsViewModel>();
        services.AddTransient<SettingsViewModel>();

        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<MainWindow>();

        return services.BuildServiceProvider();
    }
}
