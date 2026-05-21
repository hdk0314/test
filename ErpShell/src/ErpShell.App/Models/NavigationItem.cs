using System.Windows.Media;

namespace ErpShell.App.Models;

public sealed record NavigationItem(
    string Key,
    string Title,
    string IconResourceKey,
    string Group);
