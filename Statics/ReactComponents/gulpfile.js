const gulp = require('gulp');
const rename = require('gulp-rename');
const babel = require("gulp-babel");
const webpack = require('gulp-webpack');
const webpackConfig = require('./webpack.config.ms.js');
const sass = require('gulp-sass');
const merge = require('merge-stream');

webpackConfig.output.path = null;

gulp.task('build', function () {
    // place code for your default task here
    return gulp.src('./src/client.js')
        .pipe(webpack(webpackConfig))
        .pipe(gulp.dest('./dist'));
});

gulp.task('publish-css', function () {
    return gulp.src('./dist/*.css')
        .pipe(gulp.dest('../../Matterspace/Content'));
});

gulp.task('publish-js', function () {
    return gulp.src('./dist/*.js')
        .pipe(gulp.dest('../../Matterspace/Scripts/no-np'));
});

gulp.task('build-publish', ['build', 'publish-css', 'publish-js'], function () {

});

gulp.task('build-demo-prod', ['build'], function () {
    var dist = gulp.src('./dist/*')
        .pipe(gulp.dest('./demo-prod'));
    var index = gulp.src('./demo/index.prod.html')
        .pipe(rename('index.html'))
        .pipe(gulp.dest('./demo-prod'));
    return merge(dist, index);
});