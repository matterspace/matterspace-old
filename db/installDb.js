const exec = require('child_process');

const selectedCommand = process.env.COMMAND;

const commands = {
    create_dev_dbs: `
        echo ===Creating the matterspace dev db===
        createDb -E UTF8 --lc-collate C --lc-ctype C -U postgres -T template0 matterspace
        echo ===Creating the matterspace_tests dev db===
        createDb -E UTF8 --lc-collate C --lc-ctype C -U postgres -T template0 matterspace_tests
        echo ===Setting up the matterspace dev db===
        psql -f db/setupDb.sql -U postgres -d matterspace
        echo ===Setting up the matterspace_tests dev db===
        psql -f db/setupDb.sql -U postgres -d matterspace_tests
    `,
    drop_dev_dbs: `
        echo ===dropping the matterspace dev db===
        dropdb -U postgres matterspace
        echo ===dropping the matterspace_tests dev db===
        dropdb -U postgres matterspace_tests
    `,
    generate_scripts: `
        echo ===Create the setupDb.sql file===
        pg_dump --schema-only -W -w -f db/setupDb.sql -p 5432 -U postgres matterspace
    `
};

console.log("===Starting DB Command===");
console.log(`Executing ${selectedCommand}`);

commands[selectedCommand].split('\n').forEach(command => {
    console.log(exec.execSync(command).toString());
});



