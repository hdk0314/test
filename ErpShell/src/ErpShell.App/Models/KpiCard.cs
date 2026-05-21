namespace ErpShell.App.Models;

public sealed record KpiCard(
    string Title,
    string Value,
    string Delta,
    bool IsPositive,
    string IconResourceKey);
