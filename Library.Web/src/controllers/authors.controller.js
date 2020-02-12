import request from 'request'
import moment from 'moment'
import config from '../config'

const list = (req, res) => {
    request.get(config.apiUrl + 'authors', (err, response) => {
        if (err) console.log(err)
        res.render('authors.ejs', {
            icon: 'fa-user-circle',
            title: 'Authors',
            authors: JSON.parse(response.body),
            moment,
            menuId: 'authors',
            page: 'authors'
        })
    })
}


const edit = (req, res) => {
    let id = req.params.id
    if (id == 0) {
        res.render('author.ejs', {
            title: 'New author',
            author: {
                id: 0,
                image: '',
                name: '',
                dob: '',
                email: '',
                books: []
            },
            menuId: 'author'
        })
    } else {
        request.get(`${config.apiUrl}authors/${id}`, (err, response) => {
            if (err) console.log(err)
            let a = JSON.parse(response.body)
            res.render('author.ejs',
                {
                    title: a.name,
                    author: a,
                    menuId: 'author'
                }
            )
        })
    }
}

const save = (req, res) => {
    if (req.params.id==0){
        request.post(`${config.apiUrl}authors`,
        { json: 
            {
                id: req.params.id,
                image: req.body.image,
                name: req.body.name,         
                dob: req.body.dob,
                zipCode: req.body.zipCode,
                email: req.body.email
            } 
        }, (err, response)=>{
            if (err) console.log(err)
            res.redirect('/authors');
        });
    } else { 
        request.put(`${config.apiUrl}authors/${req.params.id}`,
        { json: 
            {
                id: req.params.id,
                image: req.body.image,
                name: req.body.name,         
                dob: req.body.dob,
                zipCode: req.body.zipCode,
                email: req.body.email
            } 
        }, (err, response)=>{
            if (err) console.log(err)
            res.redirect('/authors');
        });
    }
    
}

const del = (req,res) => {
    request.delete(`${config.apiUrl}authors/${req.params.id}`, (err, response)=>{
        if(err) console.log(err);
        res.redirect('/authors');
    })
}


const find =  (req, res) => {
    let filter = req.body.name;
    request.get(config.apiUrl + `authors/find/${filter}`, (err, response) => {
       if (err) console.log(err);
       res.render( 'authors.ejs', {
           icon: 'fa-users-circle',
           title: 'Authors',
           authors: JSON.parse(response.body),
           moment,
           menuId: "authors",
           page: "Authors"
       }); 
    });
}


export default { list, edit, save, del, find }