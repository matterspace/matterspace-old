const gulp = require('gulp');
const rename = require('gulp-rename');
const babel = require("gulp-babel");
const webpack = require('gulp-webpack');
const webpackConfig = require('./webpack.config.ms.js');
const sass = require('gulp-sass');

webpackConfig.output.path = null;

gulp.task('build', function () {
    // place code for your default task here
    return gulp.src('./src/client.js')
        .pipe(webpack(webpackConfig))
        .pipe(gulp.dest('./dist'));
});