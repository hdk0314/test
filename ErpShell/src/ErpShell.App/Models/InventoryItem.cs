namespace ErpShell.App.Models;

public sealed record InventoryItem(
    string Sku,
    string Name,
    string Category,
    int OnHand,
    int Reserved,
    int Reorder,
    string Location);
