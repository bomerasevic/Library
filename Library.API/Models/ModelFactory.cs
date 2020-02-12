using Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class ModelFactory
    {
        public PublisherModel Create(Publisher publisher)
        {
            return new PublisherModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
                Road = publisher.Road,
                ZipCode = publisher.ZipCode,
                City = publisher.City,
                Country = publisher.Country,
                Books = publisher.Books.Select(x => Create(x)).ToList()
            };
        }

        public BookModel Create(Book book)
        {

            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Pages = book.Pages,
                Price = book.Price,
                Image = book.Image,
                Publisher = new MasterModel { Id = book.Publisher.Id, Name = book.Publisher.Name },
                Authors = book.Authors.Select(x => new MasterModel { Id = x.Author.Id, Name = x.Author.Name }).ToList()
            };
        }

        public AuthorModel Create(Author author)
        {
            return new AuthorModel
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                Birthday = author.Birthday,
                Image = author.Image,
                Email = author.Email,
                Books = author.Books.Select(x => new MasterModel { Id = x.Book.Id, Name = x.Book.Title }).ToList()
            };
        }
    }
}
