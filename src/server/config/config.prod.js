// configurations for the dev environment
if(process.env.NODE_ENV == 'development') throw Error('Cannot read prod config in a development environment');

//TODO: Add prod settings here. This should not be committed to GitHub
//TODO: ADd this to .gitignore