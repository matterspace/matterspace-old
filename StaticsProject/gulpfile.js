const gulp = require('gulp');
const rename = require('gulp-rename');
const webpack = require('gulp-webpack');
const webpackConfig = require('./webpack.config.js');

// removes the output configuration from the webpack.config.js file, otherwise it doesn't work.
webpackConfig.output.path = null;

gulp.task('build', function () {
    // place code for your default task here
    return gulp.src('./src/index.js')
        .pipe(webpack(webpackConfig))
        .pipe(gulp.dest('./dist'));
});

gulp.task('build-ms', ['build'], function () {
    // place code for your default task here
    return gulp.src('./dist/App*') // * to include source-map
        .pipe(gulp.dest('../Matterspace/Content'));
});