import express from 'express'
import crtl from '../controllers/publishers.controller'

const router = express.Router()

router.route('/publishers')
     .get(crtl.list)

router.route('/publishers/find')
     .post(crtl.find)
     
router.route('/publishers/:id')
     .get(crtl.edit)
     .post(crtl.save)

router.route('/publishers/delete/:id')
     .get(crtl.del)


export default router 