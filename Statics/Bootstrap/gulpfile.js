const gulp = require('gulp');
const webpack = require('gulp-webpack');
const webpackApp = require('./webpack.config.app');
const webpackSite = require('./webpack.config.site');

webpackApp.output.path = null;
webpackSite.output.path = null;

gulp.task('build-app', function () {
    // place code for your default task here
    return gulp.src('./src/index.app.js')
        .pipe(webpack(webpackApp))
        .pipe(gulp.dest('./dist'));
});

gulp.task('build-site', function () {
    // place code for your default task here
    return gulp.src('./src/index.site.js')
        .pipe(webpack(webpackSite))
        .pipe(gulp.dest('./dist'));
});

gulp.task('publish', function () {
    // place code for your default task here
    return gulp.src('./dist/*.css')
        .pipe(gulp.dest('../Matterspace/Content'));
});


gulp.task('build', ['build-app', 'build-site'], function() {

});

gulp.task('build-publish', ['build', 'publish'], function() {

});