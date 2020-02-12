import express from 'express'
import crtl from '../controllers/books.controller'

const router = express.Router()

router.route('/books')
     .get(crtl.list)

router.route('/books/find')
     .post(crtl.find)
     
router.route('/books/:id')
     .get(crtl.edit)
     .post(crtl.save)

router.route('/books/delete/:id')
     .get(crtl.del)


export default router 