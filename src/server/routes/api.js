import express from 'express';
import db from '../db/db';
var router = express.Router();


/**
 * Test API
 */
router.route('/test').get((req, res) => {
    res.status(200).send({
        text: 'your text has passed'
    });
});

/**
 * Get user
 */
router.route('/users/:id').get((req, res) => {
    let entityId = req.params.id;
    db.user.findOneAsync({id: entityId})
        .then(u => {
            if(u)
                res.status(200).send(u);
            else
                res.status(404).send({
                    error: 'Could not find user'
                });
        });
});

export default router;
