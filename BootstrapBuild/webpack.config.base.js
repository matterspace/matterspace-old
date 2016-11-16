var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    entry: "./src/index.js",
    output: {
        path: './dist',
        filename: "bundle.js",
        publicPath: 'content'
    },
    module: {
        loaders: [
            {test: /\.css/, loader: ExtractTextPlugin.extract("style-loader", "css-loader")},
            {test: /\.jpe?g$|\.gif$|\.png$|\.ico$/, loader: 'file?name=[name].[ext]'},
            {test: /\.eot|\.ttf|\.svg|\.woff2?/, loader: 'file?name=[name].[ext]'},
            {test: /\.scss$/, loader:  ExtractTextPlugin.extract("style-loader", "css-loader!sass-loader")}
        ]
    },

    plugins: [
        new ExtractTextPlugin('[name].css'),
    ]
};