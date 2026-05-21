using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ErpShell.App.Views;

public sealed class IconConverter : IValueConverter
{
    public static readonly IconConverter Instance = new();

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string key &&
            Application.Current.TryFindResource(key) is Geometry g)
            return g;
        return DependencyProperty.UnsetValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => DependencyProperty.UnsetValue;
}
