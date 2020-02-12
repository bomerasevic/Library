using Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Test.TestRepositories
{
   public class TestPublishers
    {
        static LibContext context;
        static IRepository<Publisher> publishers;

        // initialize database
        public TestPublishers()
        {
            context = new TestContext();
            context.Seed();
            publishers = new Repository<Publisher>(context);
        }
        //Get publishers before any updates
        [Fact(DisplayName = "Get all publishers")]
        public void GetAll()
        {
            var collection = publishers.Get();
            Assert.Equal(2, collection.Count());
        }

        //Get all publishers from database by Id 
        [Theory(DisplayName = "Get publisher by id")]
        [InlineData(1)]
        [InlineData(2)]
        public void GetById(int id)
        {
            Publisher publisher = publishers.Get(id);
            Assert.False(publisher == null);
        }

        [Theory(DisplayName = "Get publisher by wrong id")]
        [InlineData(11)]
        [InlineData(3)]
        public void WrongId(int id)
        {
            Publisher publisher = publishers.Get(id);
            Assert.True(publisher == null);
        }


        [Fact(DisplayName = "Insert new publisher")]
        public void InsertPublisher()
        {
            Publisher publisher = new Publisher
            {
                Name = "New publisher"
            };
            publishers.Insert(publisher);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal(3, publisher.Id);
        }

        

        [Fact(DisplayName = "Update publisher ")]
        public void UpdatePublisher()
        {
            int id = 1;
            Publisher publisher = new Publisher
            {
                Id = id,
                Name = "Updated publisher"
            };
            publishers.Update(publisher, id);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
            Assert.Equal("Updated publisher", publisher.Name);
        }

        //Update more than one publisher
        [Fact(DisplayName = "Update more than one publisher")]
        public void UpdatePublishers()
        {
            int id1 = 1;
            Publisher publisher1 = new Publisher
            {
                Id = id1,
                Name = "Updated publisher1"
            };
            int id2 = 2;
            Publisher publisher2 = new Publisher
            {
                Id = id2,
                Name = "Updated publisher2"
            };
            publishers.Update(publisher1, id1);
            publishers.Update(publisher2, id2);
            int N = context.SaveChanges();
            Assert.Equal(2, N);
            Assert.Equal("Updated publisher1", publisher1.Name);
            Assert.Equal("Updated publisher2", publisher2.Name);
        }

        [Fact(DisplayName = "Update publisher with wrong id")]
        public void WrongUpdate()
        {
            int id = 3;
            Publisher p = new Publisher
            {
                Id = 2,
                Name = "Updated publisher"
            };
            publishers.Update(p, id);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }

        [Fact(DisplayName = "Delete publisher by id=2")]
        public void DeletePublisher()
        {
            publishers.Delete(2);
            int N = context.SaveChanges();
            Assert.Equal(1, N);
        }

        [Fact(DisplayName = "Delete publisher with wrong id")]
        public void WrongDelete()
        {
            publishers.Delete(5);
            int N = context.SaveChanges();
            Assert.Equal(0, N);
        }
    }
}

