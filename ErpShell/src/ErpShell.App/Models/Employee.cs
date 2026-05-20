namespace ErpShell.App.Models;

public sealed record Employee(
    string EmployeeNo,
    string Name,
    string Department,
    string Position,
    string Email,
    DateTime HireDate,
    string Status);
