const gulp = require('gulp');
const rename = require('gulp-rename');
const babel = require("gulp-babel");
const webpack = require('gulp-webpack');
const webpackConfig = require('./webpack.config.demo.prod.js');
const sass = require('gulp-sass');