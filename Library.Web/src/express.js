import express from 'express'
import bodyParser from 'body-parser'
import helmet from 'helmet'
import router from './router'

const app = express()
app.set('views', './views')
app.use(express.static('./views'))

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: true }))
app.use(helmet())

router(app)

export default app
