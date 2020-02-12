const path = require('path')
var webpack = require('webpack')
const htmlPlugin = require('html-webpack-plugin')
const nodeExternals = require('webpack-node-externals')

module.exports = {
    entry: path.join(__dirname, './src/index.js'),
    output: {
        path: path.join(__dirname, '/dist/'),
        filename: 'main.js'
    },
    externals: [nodeExternals()],
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: ['babel-loader']
            }
        ]
    },
    devServer: {
        contentBase: path.resolve(__dirname, 'dist'),
        port: 3300
    },
    plugins: [
        new htmlPlugin({
            title: 'Library project',
            favicon: './dist/favicon.png'
            // template: './src/index.html'
        })
    ]
}
