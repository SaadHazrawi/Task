namespace Application.Interface.UnitOfWork
{
   
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Author { get; }

        IBookRepository Book { get; }

        ICategoryRepository Category { get; }

        ISubCategoryRepository SubCategory { get; }

        /// <summary>
        /// Saves changes to the database. This is called when the user changes the data or saves a new version of the data.
        /// </summary>
        /// <returns>The number of changes saved or - 1 if there was an error saving the changes ( in which case the error code will be set accordingly )</returns>
        int SaveChanges();
        /// <summary>
        /// Saves changes to the data source. This is a no - op if there are no changes to save
        /// </summary>
        Task<int> SaveChangesAsync();
        
    }
}
