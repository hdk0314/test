using System.Collections.ObjectModel;
using ErpShell.App.Models;

namespace ErpShell.App.ViewModels;

public sealed class HrViewModel : ViewModelBase
{
    public HrViewModel()
    {
        Title = "인사관리";
        Subtitle = "직원 정보, 조직, 근태를 관리합니다.";

        Employees = new ObservableCollection<Employee>
        {
            new("E-2301", "김도경", "경영지원", "팀장",   "kdg@company.co.kr",  new DateTime(2018, 3, 12), "재직"),
            new("E-2302", "박서준", "영업1팀",  "차장",   "psj@company.co.kr",  new DateTime(2017, 6, 1),  "재직"),
            new("E-2303", "이수민", "재무팀",   "대리",   "lsm@company.co.kr",  new DateTime(2021, 9, 20), "재직"),
            new("E-2304", "최한나", "개발팀",   "선임",   "chn@company.co.kr",  new DateTime(2019, 1, 8),  "재직"),
            new("E-2305", "정우현", "물류팀",   "사원",   "jwh@company.co.kr",  new DateTime(2024, 5, 4),  "수습"),
            new("E-2306", "장유리", "마케팅",   "과장",   "jyr@company.co.kr",  new DateTime(2020, 11, 2), "휴직"),
        };
    }

    public ObservableCollection<Employee> Employees { get; }
}
