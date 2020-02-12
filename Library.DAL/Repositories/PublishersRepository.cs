using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL
{
    public class PublishersRepository : Repository<Publisher>
    {
        public PublishersRepository(LibContext context) : base(context) { }

        public override IQueryable<Publisher> Get() => dbSet.Include(x => x.Books).ThenInclude(x => x.Authors).ThenInclude(x => x.Author);

        public override IList<Publisher> Get(Func<Publisher, bool> where) => Get().Where(where).ToList();

        public override Publisher Get(int id) => Get().FirstOrDefault(x => x.Id == id);
    }
}
