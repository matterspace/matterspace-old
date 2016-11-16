var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    entry: "./src/index.site.js",
    output: {
        path: './dist',
        filename: "bundle.site.js",
        publicPath: 'content'
    },

    module: {
        loaders: [
            {test: /\.jpe?g$|\.gif$|\.png$|\.ico$/, loader: 'file?name=[name].[ext]'},
            {test: /\.eot|\.ttf|\.svg|\.woff2?/, loader: 'file?name=[name].[ext]'},
            {test: /\.scss$/, loader:  ExtractTextPlugin.extract("style-loader", "css-loader!sass-loader")}
        ]
    },

    plugins: [
        new ExtractTextPlugin('bootstrap.site.css'),
    ]
};