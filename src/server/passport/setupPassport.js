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
            clientID: '320185225883-if7pmgastp1ce5ksf53c84j5g3br2n8b.apps.googleusercontent.com',
            clientSecret: 'PwMafDzb_qCik76-Y0fVPs7z',
            callbackURL: 'http://localhost:4000/auth/google/callback'
        },
        function (accessToken, refreshToken, profile, done) {
            findOrCreateFromGoogleProfile(db, profile)
                .then(u => done(null, u.id))
                .catch(done);
        }
    ));
}