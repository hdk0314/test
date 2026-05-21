namespace ErpShell.App.Models;

public sealed record SalesOrder(
    string OrderNo,
    string Customer,
    string Item,
    int Quantity,
    decimal Amount,
    DateTime OrderDate,
    string Status);
