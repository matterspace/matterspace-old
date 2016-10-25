SET PGPASSWORD=@Matterspace

REM Creates the matterspace dev db
createDb -E UTF8 --lc-collate C --lc-ctype C -U postgres -T template0 matterspace

REM Creates the matterspace_tests dev db
createDb -E UTF8 --lc-collate C --lc-ctype C -U postgres -T template0 matterspace_tests

REM Sets up the matterspace dev db
psql -f setupDb.sql -U postgres -d radiscope

REM Sets up the matterspace_tests dev db
psql -f setupDb.sql -U postgres -d matterspace_tests