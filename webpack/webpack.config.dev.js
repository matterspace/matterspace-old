import webpack from 'webpack';

export default {

    entry: [
        'webpack-hot-middleware/client?path=/__webpack_hmr&timeout=20000',
        'babel-polyfill',
        './src/client/index.js'
    ],

    output: {
        filename: 'bundle.js',
        path: '/',
        publicPath: '/'
    },

    externals: undefined,

    devtool: 'source-map',

    resolve: {
        extensions: ['', '.js', '.json']
    },

    module: {
        loaders: [
            { test: /\.js/, loaders: ['babel'], exclude: /node_modules/ },
            { test: /\.jsx/, loaders: ['babel'], exclude: /node_modules/ },
            { test: /\.css/, loader: 'style-loader!css-loader' },
            { test: /\.less$/, loader: 'style!css!less' },
            { test: /\.json$/, loader: 'json' },
            { test: /\.jpe?g$|\.gif$|\.png$|\.ico$/, loader: 'file?name=[name].[ext]' },
            { test: /\.eot|\.ttf|\.svg|\.woff2?/, loader: 'file?name=[name].[ext]' },
            { test: /\.txt/, loader: 'raw' }
        ]
    },

    plugins: [
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NoErrorsPlugin(),
        new webpack.DefinePlugin({
            'process.env': {
                NODE_ENV: JSON.stringify('development'),
                APP_ENV: JSON.stringify('browser')
            }
        })
    ],


};
