import massive from 'massive';
import Promise from 'bluebird';

import entities from '../entities';

/**
 * This creates a promisified version of massive.
 * This means that we get
 * @param connectionString
 * @returns {*}
 */
export function buildMassive(connectionString) {
    if (!connectionString) throw Error('\'connectionString\' should be truthy');

    // builds the massive instance
    let massiveInstance = massive.connectSync({connectionString: connectionString});

    // promisefies the main instance and all entities declared in the entities array
    Promise.promisifyAll(massiveInstance);
    entities.forEach(e => {
        if(!massiveInstance[e])
            throw `You are trying to promisify '${e}' but it doesn't exist on the database`;
        Promise.promisifyAll(massiveInstance[e])
    });
    return massiveInstance;
}