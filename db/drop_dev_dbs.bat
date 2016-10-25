SET PGPASSWORD=@Matterspace

REM drops the matterspace dev db
dropdb -U postgres matterspace

REM drops the matterspace_tests dev db
dropdb -U postgres matterspace_tests