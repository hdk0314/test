using System.Collections.ObjectModel;
using ErpShell.App.Models;

namespace ErpShell.App.ViewModels;

public sealed class InventoryViewModel : ViewModelBase
{
    public InventoryViewModel()
    {
        Title = "재고관리";
        Subtitle = "품목, 창고, 안전재고를 실시간으로 확인합니다.";

        Items = new ObservableCollection<InventoryItem>
        {
            new("SKU-1001", "프리미엄 모니터 27\"", "디스플레이", 320, 40,  60,  "본사창고-A"),
            new("SKU-1002", "무선 키보드 K7",       "주변기기",   1280, 200, 300, "본사창고-B"),
            new("SKU-1003", "엔터프라이즈 SSD 2TB", "스토리지",   85,  20,  50,  "물류센터-1"),
            new("SKU-1004", "도킹 스테이션 X",      "주변기기",   210, 30,  80,  "물류센터-2"),
            new("SKU-1005", "산업용 라우터 R5",     "네트워크",   18,  4,   25,  "본사창고-A"),
            new("SKU-1006", "5G 라우터",            "네트워크",   140, 22,  60,  "본사창고-B"),
            new("SKU-1007", "보안 카메라 V2",       "보안장비",   430, 60,  120, "물류센터-1"),
        };
    }

    public ObservableCollection<InventoryItem> Items { get; }
}
