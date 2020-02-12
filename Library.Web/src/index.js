import config from './config'
import app from './express'
app.listen(config.port, (err)=>{
    if(err) console.log('Error starting server')
    console.log(`Server started on port ${config.port}`)
})


