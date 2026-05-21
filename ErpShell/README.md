# ErpShell

세련되고 깔끔한 ERP WPF 셸. .NET 10, C#, MVVM 패턴으로 구성된 데스크톱 앱 스켈레톤입니다.

## 특징

- **.NET 10 + WPF** — `net10.0-windows` 타겟, Per-Monitor V2 DPI 인식
- **MVVM** — `CommunityToolkit.Mvvm` (`ObservableObject`, `[RelayCommand]`, `[ObservableProperty]`)
- **DI** — `Microsoft.Extensions.DependencyInjection` 기반 서비스 컨테이너
- **테마** — 라이트/다크 동적 전환 (`Brushes.Light.xaml` ↔ `Brushes.Dark.xaml`)
- **모던 디자인 시스템**
  - 컬러 토큰 (브랜드/시맨틱/표면/텍스트)
  - 타이포그래피 스케일 (Caption ~ Display)
  - 라운드 코너, 일관된 패딩/스페이싱, 미세한 보더와 그림자 대신 surface 톤으로 깊이 표현
  - 카드, 1차/2차/아이콘 버튼, 모던 텍스트박스, 데이터그리드, 배지 등 컴포넌트 스타일
  - SVG-style 아웃라인 아이콘 (XAML Geometry)
- **레이아웃** — 좌측 사이드바 + 상단 글로벌 검색·알림·프로필 + 콘텐츠 영역
- **모듈** — 대시보드, 영업, 구매, 재고, 인사, 회계, 리포트, 설정

## 폴더 구조

```
ErpShell/
├── ErpShell.sln
└── src/
    └── ErpShell.App/
        ├── App.xaml / App.xaml.cs        # DI 부트스트랩, 리소스 병합
        ├── ErpShell.App.csproj
        ├── app.manifest                   # DPI 인식
        ├── Themes/                        # 디자인 시스템
        │   ├── Colors.xaml
        │   ├── Brushes.Light.xaml
        │   ├── Brushes.Dark.xaml
        │   ├── Typography.xaml
        │   ├── Icons.xaml
        │   └── Controls.xaml
        ├── Converters/                    # IValueConverter
        ├── Models/                        # 도메인 레코드
        ├── Services/                      # INavigationService, IThemeService
        ├── ViewModels/                    # MVVM ViewModels
        └── Views/                         # 메인 윈도우 + 각 페이지
```

## 실행

```powershell
# 사전 요구: .NET 10 SDK, Windows
cd ErpShell
dotnet restore
dotnet build
dotnet run --project src/ErpShell.App
```

## 화면 구성

- **상단바**: 글로벌 검색 (`Ctrl+K` 자리), `새로 만들기` 버튼, 알림 벨, 프로필 아바타
- **사이드바**: 브랜드 로고, 그룹별(Overview/Operations/Management/System) 메뉴, 사용자 카드 + 테마 토글
- **대시보드**: KPI 카드 4종, 최근 주문 데이터그리드, 진행률 바, 결재 카드
- **영업/구매/재고/인사/회계**: 통일된 헤더 + 액션 + 카드 + 데이터그리드 (상태 배지)
- **리포트**: 막대 차트(목업), 카테고리 비중, 리포트 라이브러리 카드
- **설정**: 회사 정보 입력, 테마 토글, 알림 옵션

## 확장 가이드

1. **새 페이지 추가**
   - `Models/` 에 도메인 레코드 추가
   - `ViewModels/` 에 `ViewModelBase` 상속 VM 추가
   - `Views/` 에 `UserControl` 추가
   - `App.xaml.cs` `ConfigureServices()` 에 등록
   - `MainWindowViewModel` 의 `NavItems` 와 `NavigationService.NavigateTo()` 분기에 추가
   - `MainWindow.xaml` 의 `DataTemplate` 매핑에 추가

2. **새 컬러 토큰**
   - `Themes/Colors.xaml` 에 `Color` 추가
   - `Themes/Brushes.Light.xaml`, `Brushes.Dark.xaml` 에 `SolidColorBrush` 양쪽 등록

3. **데이터 바인딩** — 데모 데이터는 `ViewModels/*ViewModel.cs` 생성자에 하드코딩되어 있습니다. 실제 데이터 액세스 레이어를 `Services/` 에 추가해 주입하세요.
