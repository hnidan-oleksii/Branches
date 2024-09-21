\c template1
SELECT 'CREATE DATABASE comments'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'comments')\gexec

SELECT 'CREATE DATABASE reports'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'reports')\gexec
