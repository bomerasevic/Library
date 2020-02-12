import request from 'request'
import moment from 'moment'
import config from '../config'
const list = (req, res) => {
    request.get(`${config.apiUrl}books`, (err, response) => {
        if (err) console.log(err)
        res.render('books.ejs', {
            icon: 'fa-user-circle',
            title: 'Books',
            books: JSON.parse(response.body),
            menuId: "books"
        })
    })
}
const edit = (req, res) => {
    console.log('EDIT')
    request.get(`${config.apiUrl}authors`, (error, response) => {
        if (error) console.log(error)
        const authors = JSON.parse(response.body)
        request.get(`${config.apiUrl}publishers`, (error, response) => {
            if (error) console.log(error)
            const publishers = JSON.parse(response.body)
            let id = req.params.id
            if (id == 0) {
                res.render('book.ejs', {
                    title: 'New book',
                    publishers: publishers,
                    authors: authors,
                    book: {
                        id: 0,
                        title: '',
                        description: '',
                        image: 'noimg',
                        pages: 0,
                        price: 0,
                        publisher: { id: 0, name: '' },
                        authors: []
                    }
                })
            } else {
                request.get(`${config.apiUrl}books/${id}`, (error, response) => {
                    if (error) console.log(error)
                    let book = JSON.parse(response.body)
                    res.render('book.ejs', { title: book.title, publishers: publishers, authors: authors, book: book, menuId:"books"})
                })
            }
        })
    })
}

const save = (req, res) => {
    console.log('SAVE')
    let id = req.params.id
    req.body.publisher = { id: req.body.publisherId }
    console.log(req.body)

        request.put(
            {
                url: `${config.apiUrl}books/${id}`,
                body: req.body,
                headers: { 'Content-type': 'application/json' },
                json: true
            },
            (error, response) => {
                res.redirect('/books')
            }
        )
  }

const del = (req, res) => {
    request.delete(`${config.apiUrl}books/${req.params.id}`, (err, response) => {
        if (err) console.log(err);
        res.redirect('/books');
    })
}

const find = (req, res) => {
    let filter = req.body.name;
    request.get(`${config.apiUrl}books/find/${req.body.name}`, (err, response) => {
        if (err) console.log(err);
        var temp = JSON.parse(response.body);
        temp.forEach(element => element.title = element.name)
        res.render('books.ejs', {
            icon: 'fa-users-circle',
            title: 'Books',
            books: temp,
            menuId: "books",
            page: "Books"
        });
    });
}

export default { list, edit, save, del, find }