using System.Collections.ObjectModel;
using ErpShell.App.Models;

namespace ErpShell.App.ViewModels;

public sealed class SalesViewModel : ViewModelBase
{
    public SalesViewModel()
    {
        Title = "영업관리";
        Subtitle = "주문, 견적, 고객을 한곳에서 관리합니다.";

        Orders = new ObservableCollection<SalesOrder>
        {
            new("SO-2026-0501", "(주)한빛전자",  "27\" 모니터",     20, 7_200_000m,  DateTime.Today.AddDays(-7), "완료"),
            new("SO-2026-0502", "스마트솔루션",  "무선 키보드 K7",  150, 4_500_000m, DateTime.Today.AddDays(-6), "완료"),
            new("SO-2026-0503", "코어테크",      "엔터프라이즈 SSD", 45, 14_850_000m, DateTime.Today.AddDays(-5), "출고대기"),
            new("SO-2026-0504", "퓨처랩스",      "도킹 스테이션 X", 22, 5_500_000m,  DateTime.Today.AddDays(-3), "확정"),
            new("SO-2026-0505", "그린에너지",    "산업용 라우터 R5", 8, 8_160_000m,  DateTime.Today.AddDays(-2), "확정"),
            new("SO-2026-0506", "메타텍",        "보안 카메라 V2",  120, 18_000_000m, DateTime.Today.AddDays(-1), "신규"),
            new("SO-2026-0507", "노바컴퍼니",    "5G 라우터",       60, 12_600_000m, DateTime.Today,            "신규"),
        };
    }

    public ObservableCollection<SalesOrder> Orders { get; }
}
