Working with dev databases
==========================

First, make sure that `pg_dump` is on your PATH. On Windows, it's in `C:\Program Files\PostgreSQL\9.5\bin` if you're using PG 9.5.

Creating the dev databases
--------------------------

Run these commands:

    SET PGPASSWORD=@Radiscope
    
    REM Creates the radiscope dev db
    createDb -E 'UTF8' --lc-collate C --lc-ctype C -U postgres -T template0 radiscope
    
    REM Creates the radiscope_tests dev db
    createDb -E 'UTF8' --lc-collate C --lc-ctype C -U postgres -T template0 radiscope_tests

...or the `create_dev_dbs.bat` file.

This will:

- Create the `radiscope` database.
- Create the `radiscope_tests` database.

Updating the scripts after the radiscope dev database is modified
-----------------------------------------------------------------

After the `radiscope` database is modified during development, the `setupDb.sql` script should be updated.
In order to do so, run these commands:

    SET PGPASSWORD=@Radiscope
    
    REM Create the setupDb.sql file
    pg_dump --schema-only -W -w -f setupDb.sql -p 5432 -U postgres radiscope
    
...or the `generate_scripts.bat` file.

This will:

- Update the `setupDb.sql` file.

Don't forget to commit and push the new `setupDb.sql` file to the repo.

Deleting the radiscope dev databases
------------------------------------

Run these commands:

    SET PGPASSWORD=@Radiscope
    
    REM drops the radiscope dev db
    dropdb -U postgres radiscope
    
    REM drops the radiscope_tests dev db
    dropdb -U postgres radiscope_tests
    
...or the `drop_dev_dbs.bat` file.

This will:

- Drop the `radiscope` database.
- Drop the `radiscope_tests` database.