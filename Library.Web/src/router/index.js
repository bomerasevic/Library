import publishers from './publishers.router'
import books from './books.router'
import authors from './authors.router'

export default app=>{
    app.get('/',(req,res)=>{
        res.redirect('/publishers')
        //res.render('index.ejs',{menuId:'home'})
    })
    app.use('/', publishers)
    app.use('/', books)
    app.use('/', authors)
}