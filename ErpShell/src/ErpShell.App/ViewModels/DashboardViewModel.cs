using System.Collections.ObjectModel;
using ErpShell.App.Models;

namespace ErpShell.App.ViewModels;

public sealed class DashboardViewModel : ViewModelBase
{
    public DashboardViewModel()
    {
        Title = "대시보드";
        Subtitle = "오늘의 주요 지표와 활동을 확인하세요.";

        Kpis = new ObservableCollection<KpiCard>
        {
            new("월 매출",       "₩ 482,309,000", "+12.4%", true,  "IconSales"),
            new("신규 주문",     "1,284 건",       "+8.1%",  true,  "IconPurchase"),
            new("재고 회전율",   "6.3 회",         "-2.1%",  false, "IconInventory"),
            new("미수금",        "₩ 38,920,000",  "-4.7%",  true,  "IconAccounting"),
        };

        RecentOrders = new ObservableCollection<SalesOrder>
        {
            new("SO-2026-0512", "(주)한빛전자",   "프리미엄 모니터 27\"", 12, 4_320_000m,  DateTime.Today.AddDays(-1), "확정"),
            new("SO-2026-0513", "스마트솔루션",   "무선 키보드 K7",       80, 2_400_000m,  DateTime.Today.AddDays(-1), "출고대기"),
            new("SO-2026-0514", "코어테크",       "엔터프라이즈 SSD 2TB", 30, 9_900_000m,  DateTime.Today,            "신규"),
            new("SO-2026-0515", "퓨처랩스",       "도킹 스테이션 X",      15, 3_750_000m,  DateTime.Today,            "확정"),
            new("SO-2026-0516", "그린에너지",     "산업용 라우터 R5",     6,  6_120_000m,  DateTime.Today,            "신규"),
        };
    }

    public ObservableCollection<KpiCard> Kpis { get; }
    public ObservableCollection<SalesOrder> RecentOrders { get; }
}
