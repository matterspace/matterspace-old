// configurations for the dev environment
if(process.env.NODE_ENV != 'development') throw Error('Cannot read dev config outside a development environment');

// Postgres settings
const POSTGRES_USER = 'postgres';
const POSTGRES_PASSWORD = '@Matterspace';
const POSTGRES_DATABASE = 'matterspace';
const POSTGRES_HOST = 'localhost';
const POSTGRES_PORT = 5432;

export default {
    db: {
        connectionString: `postgres://${POSTGRES_USER}:${POSTGRES_PASSWORD}@${POSTGRES_HOST}:${POSTGRES_PORT}/${POSTGRES_DATABASE}`
    }
};