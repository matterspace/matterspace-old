import config from '../config/config.js';
import { buildMassive } from './helpers/massiveHelper';


export default buildMassive(config.db.connectionString);