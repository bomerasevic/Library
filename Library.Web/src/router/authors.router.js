import express from 'express'
import ctrl from '../controllers/authors.controller'


const router = express.Router();

router.route('/authors').get(ctrl.list)
router.route('/authors/find').post(ctrl.find)

router.route('/authors/:id')
.get(ctrl.edit)
.post(ctrl.save)
.put(ctrl.save)


router.route('/authors/delete/:id').get(ctrl.del)

export default router;