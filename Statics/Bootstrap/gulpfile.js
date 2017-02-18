const gulp = require('gulp');
const webpack = require('gulp-webpack');
const webpackApp = require('./webpack.config.app');
const webpackSite = require('./webpack.config.site');

webpackApp.output.path = null;
webpackSite.output.path = null;

gulp.task('build-app', function () {
    return gulp.src('./src/index.app.js')
        .pipe(webpack(webpackApp))
        .pipe(gulp.dest('./dist'));
});

gulp.task('build-site', function () {
    return gulp.src('./src/index.site.js')
        .pipe(webpack(webpackSite))
        .pipe(gulp.dest('./dist'));
});

gulp.task('publish-css', function () {
    return gulp.src('./dist/*.css')
        .pipe(gulp.dest('../../Matterspace/Content'));
});

gulp.task('publish-js', function () {
    return gulp.src('./node_modules/bootstrap/dist/js/bootstrap.min.js')
        .pipe(gulp.dest('../../Matterspace/Scripts/no-np'));
});

gulp.task('build', ['build-app', 'build-site'], function() {

});

gulp.task('build-publish', ['build', 'publish-css', 'publish-js'], function() {

});