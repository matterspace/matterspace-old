SET PGPASSWORD=@Radiscope

REM Creates the radiscope dev db
createDb -E UTF8 --lc-collate C --lc-ctype C -U postgres -T template0 radiscope

REM Creates the radiscope_tests dev db
createDb -E UTF8 --lc-collate C --lc-ctype C -U postgres -T template0 radiscope_tests

REM Sets up the radiscope dev db
psql -f setupDb.sql -U postgres -d radiscope

REM Sets up the radiscope_tests dev db
psql -f setupDb.sql -U postgres -d radiscope_tests