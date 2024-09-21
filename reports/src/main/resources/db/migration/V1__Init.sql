CREATE TABLE posts
(
    id      INT PRIMARY KEY,
    title   varchar(255) NOT NULL,
    content TEXT
);

CREATE TABLE comments
(
    id      INT PRIMARY KEY,
    content TEXT NOT NULL
);

CREATE TABLE reportables
(
    id         SERIAL PRIMARY KEY,
    post_id    INT REFERENCES posts (Id) ON DELETE CASCADE,
    comment_id INT REFERENCES comments (Id) ON DELETE CASCADE,
    CHECK ((post_id IS NOT NULL AND comment_id IS NULL) OR
           (comment_id IS NOT NULL AND post_id IS NULL)) -- Only one of post_id or comment_id is set
);

CREATE TABLE reports
(
    id            SERIAL PRIMARY KEY,
    reported_by   INT  NOT NULL,
    reportable_id INT REFERENCES reportables (id) ON DELETE CASCADE,
    reason        TEXT NOT NULL,
    status        VARCHAR(20) CHECK (status IN ('open', 'under_review', 'resolved')) DEFAULT 'open',
    created_at    TIMESTAMP                                                          DEFAULT CURRENT_TIMESTAMP
);