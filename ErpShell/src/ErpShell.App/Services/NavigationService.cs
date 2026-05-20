using ErpShell.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ErpShell.App.Services;

public sealed class NavigationService : INavigationService
{
    private readonly IServiceProvider _services;
    private ViewModelBase? _current;

    public NavigationService(IServiceProvider services)
    {
        _services = services;
    }

    public ViewModelBase? Current
    {
        get => _current;
        private set
        {
            if (ReferenceEquals(_current, value)) return;
            _current = value;
            CurrentChanged?.Invoke();
        }
    }

    public event Action? CurrentChanged;

    public void NavigateTo(string key)
    {
        Current = key switch
        {
            "dashboard"  => _services.GetRequiredService<DashboardViewModel>(),
            "sales"      => _services.GetRequiredService<SalesViewModel>(),
            "purchases"  => _services.GetRequiredService<PurchasesViewModel>(),
            "inventory"  => _services.GetRequiredService<InventoryViewModel>(),
            "hr"         => _services.GetRequiredService<HrViewModel>(),
            "accounting" => _services.GetRequiredService<AccountingViewModel>(),
            "reports"    => _services.GetRequiredService<ReportsViewModel>(),
            "settings"   => _services.GetRequiredService<SettingsViewModel>(),
            _            => _services.GetRequiredService<DashboardViewModel>(),
        };
    }
}
