SET PGPASSWORD=@Matterspace

REM Create the setupDb.sql file
pg_dump --schema-only -W -w -f setupDb.sql -p 5432 -U postgres matterspace