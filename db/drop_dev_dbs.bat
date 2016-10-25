SET PGPASSWORD=@Radiscope

REM drops the radiscope dev db
dropdb -U postgres radiscope

REM drops the radiscope_tests dev db
dropdb -U postgres radiscope_tests