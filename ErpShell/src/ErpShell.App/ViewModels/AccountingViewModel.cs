using System.Collections.ObjectModel;
using ErpShell.App.Models;

namespace ErpShell.App.ViewModels;

public sealed class AccountingViewModel : ViewModelBase
{
    public AccountingViewModel()
    {
        Title = "회계관리";
        Subtitle = "전표, 손익, 잔액을 한곳에서 추적합니다.";

        Entries = new ObservableCollection<JournalEntry>
        {
            new("JE-0001", DateTime.Today.AddDays(-5), "매출",         "한빛전자 매출 인식",   0m,           7_200_000m),
            new("JE-0002", DateTime.Today.AddDays(-5), "외상매출금",   "한빛전자",            7_200_000m,    0m),
            new("JE-0003", DateTime.Today.AddDays(-3), "급여",         "5월 급여 지급",       42_000_000m,   0m),
            new("JE-0004", DateTime.Today.AddDays(-3), "예금",         "5월 급여 출금",        0m,          42_000_000m),
            new("JE-0005", DateTime.Today.AddDays(-1), "재료비",       "PCB 자재 입고",        6_900_000m,    0m),
            new("JE-0006", DateTime.Today,             "외상매입금",   "프린텍",              0m,           6_900_000m),
        };
    }

    public ObservableCollection<JournalEntry> Entries { get; }
}
