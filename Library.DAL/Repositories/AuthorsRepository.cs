using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL
{
    public class AuthorsRepository : Repository<Author>
    {
        public AuthorsRepository(LibContext context) : base(context) { }

        public override IQueryable<Author> Get() => dbSet.Include(x => x.Books).ThenInclude(x => x.Book);

        public override IList<Author> Get(Func<Author, bool> where) => Get().Where(where).ToList();

        public override Author Get(int id) => Get().FirstOrDefault(x => x.Id == id);
    }
}