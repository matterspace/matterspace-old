var config;
switch(process.env.NODE_ENV) {
    case 'development':
        config = require('./config.dev');
        break;
    default:
        config = require('./config.prod');
        break;
}
export default config;
