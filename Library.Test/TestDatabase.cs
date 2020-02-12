using System;
using System.Collections.Generic;
using System.Text;
using Library.DAL;

namespace Library.Test
{
    public static class TestDatabase
    {

        public static void Seed(this LibContext dbContext)
        {
            //create a brand new database and seed it with some mock data
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            //add entities for dbcontext instance
            //adding publishers
            dbContext.Publishers.Add(new Publisher
            {
                Name = "Svjetlost Komerc",
                City = "Sarajevo",
                Country = "BiH",
                Road = "Marsala Tita",
                ZipCode = "71000"
            });
            dbContext.Publishers.Add(new Publisher
            {
                Name = "Sarajevo Publishing",
                City = "Sarajevo",
                Country = "BiH",
                Road = "Kulovica 19",
                ZipCode = "71000"
            });
            dbContext.SaveChanges();

            //adding books
            dbContext.Books.Add(new Book
            {
                Title = "Bojanka za odrasle",
                Publisher = dbContext.Publishers.Find(1)
            });

            dbContext.Books.Add(new Book
            {
                Title = "Jabuka i kruska",
                Publisher = dbContext.Publishers.Find(2)
            });

            dbContext.Books.Add(new Book
            {
                Title = "Digitalna fotografija",
                Publisher = dbContext.Publishers.Find(1)
            });

            dbContext.Books.Add(new Book
            {
                Title = "Aronija i kukuruz",
                Publisher = dbContext.Publishers.Find(1)
            });

            //adding authors
            dbContext.Authors.Add(new Author
            {
                Name = "Narcisa Turkovic"
            });

            dbContext.Authors.Add(new Author
            {
                Name = "Branko Copic"
            });

            dbContext.Authors.Add(new Author
            {
                Name = "Mili Marota"
            });

            dbContext.SaveChanges();

            //adding authbooks
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(1),
                Book = dbContext.Books.Find(1)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(1),
                Book = dbContext.Books.Find(4)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(2),
                Book = dbContext.Books.Find(2)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(2),
                Book = dbContext.Books.Find(3)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(3),
                Book = dbContext.Books.Find(1)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(3),
                Book = dbContext.Books.Find(2)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(3),
                Book = dbContext.Books.Find(3)
            });
            dbContext.AuthBooks.Add(new AuthBooks
            {
                Author = dbContext.Authors.Find(2),
                Book = dbContext.Books.Find(4)
            });
            Console.WriteLine("Ok");
            dbContext.SaveChanges();
        }
    }
}