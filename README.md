# 공지사항 게시판

간단한 공지사항 게시판 애플리케이션입니다.

## 기능

- 공지사항 목록 조회
- 공지사항 상세 보기
- 공지사항 작성/수정/삭제
- 공지사항 고정 기능
- 조회수 카운트
- 날짜순 정렬

## 기술 스택

- **백엔드**: Node.js + Express
- **프론트엔드**: EJS 템플릿 엔진
- **데이터베이스**: SQLite3
- **스타일**: 순수 CSS

## 설치 및 실행

### 1. 의존성 설치

```bash
npm install
```

### 2. 서버 실행

```bash
npm start
```

또는 개발 모드로 실행 (nodemon 사용):

```bash
npm run dev
```

### 3. 브라우저에서 접속

```
http://localhost:3000
```

## 프로젝트 구조

```
.
├── server.js           # Express 서버 및 라우트
├── database.js         # SQLite 데이터베이스 설정
├── package.json        # 프로젝트 설정 및 의존성
├── views/              # EJS 템플릿 파일
│   ├── index.ejs       # 공지사항 목록
│   ├── detail.ejs      # 공지사항 상세
│   └── form.ejs        # 작성/수정 폼
├── public/             # 정적 파일
│   └── css/
│       └── style.css   # 스타일시트
└── notices.db          # SQLite 데이터베이스 (자동 생성)
```

## API 엔드포인트

- `GET /` - 공지사항 목록
- `GET /notices/new` - 공지사항 작성 폼
- `POST /notices` - 공지사항 생성
- `GET /notices/:id` - 공지사항 상세 보기
- `GET /notices/:id/edit` - 공지사항 수정 폼
- `PUT /notices/:id` - 공지사항 수정
- `DELETE /notices/:id` - 공지사항 삭제

## 데이터베이스 스키마

```sql
CREATE TABLE notices (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  title TEXT NOT NULL,
  content TEXT NOT NULL,
  author TEXT NOT NULL,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  views INTEGER DEFAULT 0,
  is_pinned INTEGER DEFAULT 0
);
```

## 라이선스

ISC
