import config from '../config.test';
import { buildMassive } from '../../../src/server/db/helpers/massiveHelper';
import entities from '../../../src/server/db/entities';

/**
 * Truncates (delete) data from all tables
 * @param db
 */
function truncateData(db) {
    if (!db) throw Error('\'db\' should be truthy');

    // concatenates all entities from the database
    let entitiesAsString = entities.map(e => `"${e}"`).join(', ');

    // nukes the database (puff.. nothing left)
    return db.runAsync(`truncate ${entitiesAsString} cascade`);
}

/**
 * Sets up a database test session
 * @param before
 * @param after
 */
export default function setupSession(before, after, beforeEach, afterEach, callback) {
    if (!before) throw Error('\'before\' should be truthy');
    if (!after) throw Error('\'after\' should be truthy');

    let db = null;

    // runs before all tests in a file
    before((done) => {
            try {
                db = buildMassive(config.db.connectionString);
                callback(db);
                done();
            }
            catch (ex) {
                if (db) db.end();
                done(ex);
            }
        }
    );

    // runs before each test in a file
    beforeEach((done) => {
        truncateData(db)
            .then(() => done());
    });

    // runs after all tests in a file
    after((done) => {
        done();
    });
};