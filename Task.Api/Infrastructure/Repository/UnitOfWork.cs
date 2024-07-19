
using Application.Interface;
using Application.Interface.UnitOfWork;
using Infrastructure.Data;


namespace Infrastructure.Repository
{
     
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        // repositories

        private readonly AppDataContext _context;
        public IAuthorRepository Author { get; }
        public IBookRepository Book { get; }
        public ICategoryRepository Category { get; }
        public ISubCategoryRepository SubCategory { get; }
        public UnitOfWork(AppDataContext context)
        {
            _context = context;
            Book = new BookRepository(_context);
            Author = new AuthorRepository(_context);
            Category = new CategoryRepository(_context);
            SubCategory = new SubCategoryRepository(_context);
        }
        //public UnitOfWork(bool disposed, AppDataContext context, IAuthorRepository author, IBookRepository book, ICategoryRepository category, ISubCategoryRepository subCategory)
        //{
        //    _context = context;
        //    Author = author;
        //    Book = book;
        //    Category = category;
        //    SubCategory = subCategory;
        //}
        // save changes
        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        // dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
