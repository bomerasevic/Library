using System;

namespace Library.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly LibContext _context;
        private IRepository<Author> _authors;
        private IRepository<Book> _books;
        private IRepository<Publisher> _publishers;
        private IRepository<AuthBooks> _authbooks;


        public UnitOfWork(LibContext context = null) => _context = context ?? (context = new LibContext());
        
        public LibContext Context => _context;

        public IRepository<Author> Authors => _authors ?? (_authors = new AuthorsRepository(_context));
        public IRepository<Book> Books => _books ?? (_books = new BooksRepository(_context));
        public IRepository<Publisher> Publishers => _publishers ?? (_publishers = new PublishersRepository(_context));
        public IRepository<AuthBooks> AuthBooks => _authbooks ?? (_authbooks = new Repository<AuthBooks>(_context));

        public int Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
