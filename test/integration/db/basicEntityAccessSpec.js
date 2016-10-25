import setupSession from './setupSession';
import {assertCanSaveFindAndDelete} from './dbTestHelper';


describe('basicEntitiAccess', function () {

    let db = null;
    setupSession(before, after, beforeEach, afterEach, $db => {
        db = $db;
    });

    it('can save, find and delete users', done => {
        let user = {
            email: 'andrerpena@gmail.com',
            display_name: 'André Pena'
        };
        assertCanSaveFindAndDelete(db, 'user', user)
            .then(() => done())
            .catch(done);
    });

    it('can save, find and delete tasks', done => {
        // we need a user for the task
        db.user.saveAsync({
            email: 'andrerpena@gmail.com',
            display_name: 'André Pena'
        })
            .then((user) => {
                let task = {
                    user_id: user.id,
                    text: 'Do something coooool!'
                };
                assertCanSaveFindAndDelete(db, 'task', task, done)
                    .then(() => done())
                    .catch(done);
            });
    });
});