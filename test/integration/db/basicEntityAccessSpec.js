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
            name: 'andrerpena',
            display_name: 'André Pena'
        };
        assertCanSaveFindAndDelete(db, 'user', user)
            .then(() => done())
            .catch(done);
    });

    it('can save, find and delete threads', done => {
        // we need a user for the task
        db.user.saveAsync({
            email: 'andrerpena@gmail.com',
            name: 'andrerpena',
            display_name: 'André Pena'
        })
            .then((user) => {
                let thread = {
                    created_by: user.id,
                    created_at: new Date(1995, 11, 17),
                    text_md: 'Do something coooool!'
                };
                assertCanSaveFindAndDelete(db, 'thread', thread, done)
                    .then(() => done())
                    .catch(done);
            });
    });
});