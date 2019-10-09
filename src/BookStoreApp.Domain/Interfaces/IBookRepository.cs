using BookStoreApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByCategory(Guid categoryId);
        Task<IEnumerable<Book>> GetBooksCategories();
        Task<Book> GetBookCategory(Guid id);


        
    }
}
