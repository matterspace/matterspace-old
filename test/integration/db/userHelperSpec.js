import {assert} from 'chai';
import setupSession from './setupSession';
import googleProfileSample from "./resources/googleProfileSample.js";
import {createFromGoogleProfile, updateFromGoogleProfile, findOrCreateFromGoogleProfile}  from '../../../src/server/db/entityHelpers/userHelper';


describe('userHelper', function () {

    let db = null;
    setupSession(before, after, beforeEach, afterEach, $db => {
        db = $db;
    });

    it('createFromGoogleProfile', done => {
        createFromGoogleProfile(db, googleProfileSample)
            .then(u => {
                assert.isOk(u);
                // let's go to the database to see if the user has actually been added
                return db.user.findOneAsync(u.id);
            })
            .then(u => {
                assert.isOk(u);
                assert.isOk(u.oauth_profiles);
                assert.strictEqual(u.oauth_profiles.google.id, '109199054588840596357');
                return db.user.destroyAsync({id: u.id});
            })
            .then(() => done())
            .catch(done);
    });

    it('updateFromGoogleProfile', done => {
        db.user.saveAsync({
            email: 'andrerpena@gmail.com',
            name: 'andrerpena',
            display_name: 'André Pena'
        })
            .then(u => updateFromGoogleProfile(db, u, googleProfileSample))
            .then(u => {
                assert.isOk(u);
                assert.isOk(u.oauth_profiles);
                assert.strictEqual(u.oauth_profiles.google.id, '109199054588840596357');
                return db.user.destroyAsync({id: u.id})
            })
            .then(() => done())
            .catch(done);
    });

    describe('findOrCreateFromGoogleProfile', () => {
        it('when the user did not exist yet', done => {
            db.user.findOneAsync({email: 'andrerpena@gmail.com'})
                .then(u => {
                    assert.isUndefined(u);
                    return findOrCreateFromGoogleProfile(db, googleProfileSample)
                })
                .then(u => {
                    assert.strictEqual(u.email, 'andrerpena@gmail.com');
                    return db.user.destroyAsync({id: u.id});
                })
                .then(() => done())
                .catch(done);
        });
        it('when a user with the same e-mail address already existed', done => {
            db.user.saveAsync({
                email: 'andrerpena@gmail.com',
                name: 'andrerpena',
                display_name: 'André Pena'
            })
                .then(() => findOrCreateFromGoogleProfile(db, googleProfileSample))
                .then(u => {
                    assert.strictEqual(u.email, 'andrerpena@gmail.com');
                    assert.ok(u.oauth_profiles.google);
                    return db.user.destroyAsync({id: u.id});
                })
                .then(() => done())
                .catch(done);
        });
    });
});