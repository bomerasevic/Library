using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.DAL
{
    public class BooksRepository: Repository<Book>
    {
        public BooksRepository(LibContext context) : base(context) { }

        public override IQueryable<Book> Get()
        {
            return dbSet.Include(x => x.Publisher).Include(x => x.Authors).ThenInclude(x => x.Author);
        }

        public override IList<Book> Get(Func<Book, bool> where)
        {
            IList<Book> list;
            IQueryable<Book> dbQuery = Get();
            list = dbQuery.Where(where).ToList();
            return list;
        }

        public override Book Get(int id)
        {
            Book book;
            IQueryable<Book> dbQuery = Get();
            book = dbQuery.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public override void Update(Book book, int id)
        {
            Book old = Get(id);
            if (old != null)
            {
                _context.Entry(old).CurrentValues.SetValues(book);
                old.Publisher = book.Publisher;
            }
        }
    }
}
