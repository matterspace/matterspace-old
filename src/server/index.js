import React from 'react';
import express, {Router} from 'express';
import cookieParser from 'cookie-parser';
import bodyParser  from 'body-parser';
import cookieSession from 'cookie-session';
import webpackConfig from '../../webpack.config.dev';
import colors from 'colors';
import webpackMiddleware from 'webpack-dev-middleware';
import webpackHotMiddleware from 'webpack-hot-middleware';
import webpack from 'webpack';
import passport from 'passport';
import setupPassport from './passport/setupPassport';
// routes
import authRoute from './routes/auth';
import apiRoute from './routes/api';
import appRoute from './routes/app';

const webpackCompiler = webpack(webpackConfig);

let app = express();

setupPassport(passport);
app.use(cookieParser());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
    extended: true
}));
app.use(cookieSession({
    name: 'session',
    keys: ['key1', 'key2']
}));
app.use(passport.initialize());
app.use(passport.session());

app.use(webpackMiddleware(webpackCompiler));
app.use(webpackHotMiddleware(webpackCompiler));

// routes
app.use('/auth', authRoute);
app.use('/api', apiRoute);
app.use('', appRoute);

app.listen(4000, '0.0.0.0', () => {
    console.log(colors.green(`Radiscope started at http://localhost:4000/. NODE_ENV: ${process.env.NODE_ENV}`));
});