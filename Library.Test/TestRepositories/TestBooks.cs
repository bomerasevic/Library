using Library.DAL;
using System.Linq;
using Xunit;

namespace Library.Test
{
    public class TestBooks
    {
        static LibContext context;
        static IRepository<Book> books;

        // initialize database
        public TestBooks()
        {
            context = new TestContext();
            context.Seed();
            books = new Repository<Book>(context);
        }
        //Before any updates
        [Fact(DisplayName = "Get all books")]
        public void GetAll()
        {
            var collection = books.Get();
            Assert.Equal(4, collection.Count());
        }

        //Get all books from database by Id
        [Theory(DisplayName = "Get book by id")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetById(int id)
        {
            Book book = books.Get(id);
            Assert.False(book == null);
        }

        //Get books with wrong Id
        [Theory(DisplayName = "Get book by wrong Id")]
        [InlineData(6)]
        [InlineData(20)]
        public void WrongId(int id)
        {
            Book book = books.Get(id);
            Assert.True(book == null);
        }

        [Fact(DisplayName = "Insert new book")]
        public void InsertBook()
        {
            Book book = new Book
            {
                Title = "Ugursuz"
            };
            books.Insert(book);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal(5, book.Id);
        }

        [Fact(DisplayName = "Update book by Id=1")]
        public void UpdateBook()
        {
            int id = 1;
            Book book = new Book
            {
                Id = id,
                Title = "Updated book"
            };
            books.Update(book, id);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal("Updated book", book.Title);
        }

        [Fact(DisplayName = "Update more than one book")]
        public void UpdateBooks()
        {
            int id1 = 1;
            int id2 = 2;
            Book book1 = new Book
            {
                Id = id1,
                Title = "Updated book1"
            };
            Book book2 = new Book
            {
                Id = id2,
                Title = "Updated book2"
            };
            books.Update(book1, id1);

            books.Update(book2, id2);
            int N = context.SaveChanges();
            Assert.Equal(2, N);
            Assert.Equal("Updated book1", book1.Title);

            Assert.Equal("Updated book2", book2.Title);
        }

        [Fact(DisplayName = "Update book with wrong id")]
        public void WrongUpdate()
        {
            int id = 4;
            Book book = new Book
            {
                Id = 4,
                Title = "Updated book 2"
            };
            books.Update(book, id + 1);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }

        [Fact(DisplayName = "Delete book by id=1")]
        public void DeleteBook()
        {
            books.Delete(1);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
        }

        [Fact(DisplayName = "Delete book with wrong id")]
        public void WrongDelete()
        {
            books.Delete(8);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }
    }
}