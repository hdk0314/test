using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ErpShell.App.Converters;

public sealed class StatusToBrushConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var status = value?.ToString() ?? string.Empty;
        return status switch
        {
            "완료" or "입고완료" or "재직"           => new SolidColorBrush(Color.FromRgb(0x10, 0xB9, 0x81)),
            "확정" or "출고대기" or "입고대기"       => new SolidColorBrush(Color.FromRgb(0x3B, 0x82, 0xF6)),
            "신규" or "발주" or "수습"               => new SolidColorBrush(Color.FromRgb(0xF5, 0x9E, 0x0B)),
            "취소" or "휴직" or "반려"               => new SolidColorBrush(Color.FromRgb(0xEF, 0x44, 0x44)),
            _                                        => new SolidColorBrush(Color.FromRgb(0x94, 0xA3, 0xB8)),
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => DependencyProperty.UnsetValue;
}
