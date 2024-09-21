CREATE TABLE comments
(
    id SERIAL PRIMARY KEY,
    post_id    INT  NOT NULL,
    user_id    INT  NOT NULL,
    content    TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
CREATE TABLE comment_votes
(
    id    SERIAL PRIMARY KEY,
    comment_id INT REFERENCES comments (id),
    user_id    INT NOT NULL,
    vote_type  SMALLINT CHECK (vote_type IN (1, -1)),
    voted_at   TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
