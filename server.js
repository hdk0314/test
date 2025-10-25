const express = require('express');
const bodyParser = require('body-parser');
const methodOverride = require('method-override');
const path = require('path');
const db = require('./database');

const app = express();
const PORT = process.env.PORT || 3000;

// 미들웨어 설정
app.set('view engine', 'ejs');
app.set('views', path.join(__dirname, 'views'));
app.use(express.static(path.join(__dirname, 'public')));
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(methodOverride('_method'));

// 라우트: 공지사항 목록
app.get('/', (req, res) => {
  const sql = `
    SELECT * FROM notices
    ORDER BY is_pinned DESC, created_at DESC
  `;

  db.all(sql, [], (err, notices) => {
    if (err) {
      console.error(err);
      return res.status(500).send('서버 오류가 발생했습니다.');
    }
    res.render('index', { notices });
  });
});

// 라우트: 공지사항 작성 폼
app.get('/notices/new', (req, res) => {
  res.render('form', { notice: null, mode: 'create' });
});

// 라우트: 공지사항 생성
app.post('/notices', (req, res) => {
  const { title, content, author, is_pinned } = req.body;
  const pinnedValue = is_pinned ? 1 : 0;

  const sql = `
    INSERT INTO notices (title, content, author, is_pinned)
    VALUES (?, ?, ?, ?)
  `;

  db.run(sql, [title, content, author, pinnedValue], (err) => {
    if (err) {
      console.error(err);
      return res.status(500).send('공지사항 생성 중 오류가 발생했습니다.');
    }
    res.redirect('/');
  });
});

// 라우트: 공지사항 상세 보기
app.get('/notices/:id', (req, res) => {
  const { id } = req.params;

  // 조회수 증가
  db.run('UPDATE notices SET views = views + 1 WHERE id = ?', [id]);

  const sql = 'SELECT * FROM notices WHERE id = ?';

  db.get(sql, [id], (err, notice) => {
    if (err) {
      console.error(err);
      return res.status(500).send('서버 오류가 발생했습니다.');
    }
    if (!notice) {
      return res.status(404).send('공지사항을 찾을 수 없습니다.');
    }
    res.render('detail', { notice });
  });
});

// 라우트: 공지사항 수정 폼
app.get('/notices/:id/edit', (req, res) => {
  const { id } = req.params;

  db.get('SELECT * FROM notices WHERE id = ?', [id], (err, notice) => {
    if (err) {
      console.error(err);
      return res.status(500).send('서버 오류가 발생했습니다.');
    }
    if (!notice) {
      return res.status(404).send('공지사항을 찾을 수 없습니다.');
    }
    res.render('form', { notice, mode: 'edit' });
  });
});

// 라우트: 공지사항 수정
app.put('/notices/:id', (req, res) => {
  const { id } = req.params;
  const { title, content, author, is_pinned } = req.body;
  const pinnedValue = is_pinned ? 1 : 0;

  const sql = `
    UPDATE notices
    SET title = ?, content = ?, author = ?, is_pinned = ?, updated_at = CURRENT_TIMESTAMP
    WHERE id = ?
  `;

  db.run(sql, [title, content, author, pinnedValue, id], (err) => {
    if (err) {
      console.error(err);
      return res.status(500).send('공지사항 수정 중 오류가 발생했습니다.');
    }
    res.redirect(`/notices/${id}`);
  });
});

// 라우트: 공지사항 삭제
app.delete('/notices/:id', (req, res) => {
  const { id } = req.params;

  db.run('DELETE FROM notices WHERE id = ?', [id], (err) => {
    if (err) {
      console.error(err);
      return res.status(500).send('공지사항 삭제 중 오류가 발생했습니다.');
    }
    res.redirect('/');
  });
});

// 서버 시작
app.listen(PORT, () => {
  console.log(`공지사항 게시판이 http://localhost:${PORT} 에서 실행 중입니다.`);
});
