INSERT INTO posts (id, title, content)
VALUES (1, 'First Post', 'This is the content of the first post.'),
       (2, 'Second Post', 'This is the content of the second post.'),
       (3, 'Third Post', 'This is the content of the third post.'),
       (4, 'Fourth Post', 'This is the content of the fourth post.'),
       (5, 'Fifth Post', 'This is the content of the fifth post.'),
       (6, 'Sixth Post', 'This is the content of the sixth post.'),
       (7, 'Seventh Post', 'This is the content of the seventh post.'),
       (8, 'Eighth Post', 'This is the content of the eighth post.'),
       (9, 'Ninth Post', 'This is the content of the ninth post.'),
       (10, 'Tenth Post', 'This is the content of the tenth post.');

INSERT INTO comments (id, content)
VALUES (1, 'First comment on a post.'),
       (2, 'Second comment on a post.'),
       (3, 'Third comment on a post.'),
       (4, 'Fourth comment on a post.'),
       (5, 'Fifth comment on a post.'),
       (6, 'Sixth comment on a post.'),
       (7, 'Seventh comment on a post.'),
       (8, 'Eighth comment on a post.'),
       (9, 'Ninth comment on a post.'),
       (10, 'Tenth comment on a post.');

INSERT INTO reportables (post_id, comment_id)
VALUES (1, NULL),
       (2, NULL),
       (3, NULL),
       (4, NULL),
       (5, NULL),
       (NULL, 1),
       (NULL, 2),
       (NULL, 3),
       (NULL, 4),
       (NULL, 5);

INSERT INTO reports (reported_by, reportable_id, reason, status)
VALUES (101, 1, 'Inappropriate content in post', 'open'),
       (102, 2, 'Spam in post', 'under_review'),
       (103, 3, 'Misleading information in post', 'resolved'),
       (104, 6, 'Offensive comment', 'open'),
       (105, 7, 'Comment contains personal information', 'under_review'),
       (106, 4, 'Hate speech in post', 'open'),
       (107, 8, 'Comment is abusive', 'resolved'),
       (108, 5, 'Post violates community guidelines', 'resolved'),
       (109, 9, 'Comment promotes violence', 'under_review'),
       (110, 10, 'Comment is spam', 'open');
