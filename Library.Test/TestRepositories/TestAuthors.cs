using Library.DAL;
using System.Linq;
using Xunit;

namespace Library.Test
{
    public class TestAuthors
    {
        static LibContext context;
        static IRepository<Author> authors;

        // initialize database
        public TestAuthors()
        {
            context = new TestContext();
            context.Seed();
            authors = new Repository<Author>(context);
        }
        //Get all authors before update
        [Fact(DisplayName = "Get all authors")]
        public void GetAll()
        {
            var collection = authors.Get();
            Assert.Equal(3, collection.Count());
        }

        //Get all authors from database by Id
        [Theory(DisplayName = "Get author by id")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetById(int id)
        {
            Author author = authors.Get(id);
            Assert.False(author == null);
        }

       
        [Theory(DisplayName = "Get author by wrong id")]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(100)]
        public void WrongId(int id)
        {
            Author author = authors.Get(id);
            Assert.True(author == null);
        }


        [Fact(DisplayName = "Insert new author")]
        public void InsertAuthor()
        {
            Author a = new Author
            {
                Name = "New author"
            };
            authors.Insert(a);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal(4, a.Id);
        }

        [Fact(DisplayName = "Update author by Id=3")]
        public void UpdateAuthor()
        {
            int id = 3;
            Author a = new Author
            {
                Id = id,
                Name = "Updated author"
            };
            authors.Update(a, id);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal("Updated author", a.Name);
        }



        [Fact(DisplayName = "Update author with wrong id")]
        public void WrongUpdate()
        {
            int id = 9;
            Author a = new Author
            {
                Id = 1,
                Name = "Updated author"
            };
            authors.Update(a, id + 1);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }

        [Fact(DisplayName = "Delete author by id 1 ")]
        public void DeleteAuthor()
        {
            authors.Delete(1);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
        }

        [Theory(DisplayName = "Delete author with wrong id")]
        [InlineData(4)]
        [InlineData(8)]
        [InlineData(100)]
        public void WrongDelete(int id)
        {
            authors.Delete(id);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }
    }
}