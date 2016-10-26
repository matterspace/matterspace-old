import db from '../db/db';
import {findOrCreateFromGoogleProfile} from '../db/entityHelpers/userHelper';
import { Strategy as GoogleStrategy } from 'passport-google-oauth2';

/**
 * Setups up passport
 * @param passport
 */
export default function (passport) {
    if (!passport) throw Error('\'passport\' should be truthy');

    passport.serializeUser(function (userId, done) {
        done(null, userId);
    });

    passport.deserializeUser(function (userId, done) {
        db.user.findOneAsync({id: userId})
            .then(u => done(null, u))
            .catch(done);
    });

    // sets up passport for Google
    passport.use(new GoogleStrategy(
        {
            clientID: '319064571712-2fuj8m6gj1n6cf71kubolr6rahg6ekhl.apps.googleusercontent.com',
            clientSecret: 'sx9NRvIwB9kzfwAt0P6r97HI',
            callbackURL: 'http://localhost:4000/auth/google/callback'
        },
        function (accessToken, refreshToken, profile, done) {
            findOrCreateFromGoogleProfile(db, profile)
                .then(u => done(null, u.id))
                .catch(done);
        }
    ));
}