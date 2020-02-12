import request from 'request'
import moment from 'moment'
import config from '../config'
const list = (req, res) => {
   request.get(config.apiUrl + 'publishers', (err, response) => {
       if (err) console.log(err)
    //    console.log(response.body)
       res.render('publishers.ejs', {
           icon: 'fa-user-circle',
           title: 'Publishers',
           publishers: JSON.parse(response.body),
           moment,
           menuId: 'publishers'
       })
   })
}
const edit = (req, res) => {
   let id = req.params.id
   if (id == 0) {
       res.render('publisher.ejs', {
           title: 'New publisher',
           publisher: {
               id: 0,
               name: '',
               road: '',
               city: '',
               zipCode: '',
               country: '',
               books: []
           },
           menuId: 'publisher'
       })
   } else {
       request.get(`${config.apiUrl}publishers/${id}`, (err, response) => {
           if (err) console.log(err)
           let pub = JSON.parse(response.body)
           res.render('publisher.ejs',
               {
                   title: pub.name,
                   publisher: pub,
                   menuId: 'publisher'
               }
           )
       })
   }
}
const save = (req, res) => {
    if (req.params.id == 0){
        request.post(`${config.apiUrl}publishers`,
        { json:
            {
                id: 0,
                name: req.body.name,
                road: req.body.road,
                city: req.body.city,
                zipCode: req.body.zipCode,
                country: req.body.country
            }
        }, (err, response)=>{
            if (err) console.log(err)
            res.redirect('/publishers');
        });
    } else {
        request.put(`${config.apiUrl}publishers/${req.params.id}`,
        { json:
            {
                id: req.params.id,
                name: req.body.name,
                road: req.body.road,
                city: req.body.city,
                zipCode: req.body.zipCode,
                country: req.body.country
            }
        }, (err, response)=>{
            if (err) console.log(err)
            res.redirect('/publishers');
        });
    }
  }
  
  const del = (req, res) =>{
      request.delete(`${config.apiUrl}publishers/${req.params.id}`,(err,response)=>{
          if(err) console.log(err);
          res.redirect('/publishers')
      })
  }

  const find =  (req, res) => {
    console.log('bilo sta prije', req.body.name)
    request.get(`${config.apiUrl}publishers/find/${req.body.name}`, (err, response) => {
       if (err) console.log(err);
       console.log('bilo sta poslije')
    //    response.body.forEach(item => console.log(item.name));
       res.render( 'publishers.ejs', {
           icon: 'fa-users-circle',
           title: 'Publishers',
           publishers: JSON.parse(response.body),
           menuId: "publishers",
           page: "Publishers"
       });
    });
 }

export default { list, edit, save, del, find }  // {} zato sto exportujemo vise f-ja