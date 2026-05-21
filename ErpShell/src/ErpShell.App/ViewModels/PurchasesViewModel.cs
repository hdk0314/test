using System.Collections.ObjectModel;
using ErpShell.App.Models;

namespace ErpShell.App.ViewModels;

public sealed class PurchasesViewModel : ViewModelBase
{
    public PurchasesViewModel()
    {
        Title = "구매관리";
        Subtitle = "발주서, 거래처, 입고 일정을 관리합니다.";

        PurchaseOrders = new ObservableCollection<SalesOrder>
        {
            new("PO-2026-0301", "에이스부품",   "LCD 패널 27\"",   200, 28_000_000m, DateTime.Today.AddDays(-10), "입고완료"),
            new("PO-2026-0302", "동부메탈",     "알루미늄 케이스", 500, 12_500_000m, DateTime.Today.AddDays(-7),  "입고완료"),
            new("PO-2026-0303", "한국반도체",   "컨트롤러 IC",     1000, 9_800_000m, DateTime.Today.AddDays(-3),  "입고대기"),
            new("PO-2026-0304", "프린텍",       "PCB 보드",        300, 6_900_000m,  DateTime.Today,             "발주"),
        };
    }

    public ObservableCollection<SalesOrder> PurchaseOrders { get; }
}
