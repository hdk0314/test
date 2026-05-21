namespace ErpShell.App.Models;

public sealed record JournalEntry(
    string EntryNo,
    DateTime Date,
    string Account,
    string Description,
    decimal Debit,
    decimal Credit);
