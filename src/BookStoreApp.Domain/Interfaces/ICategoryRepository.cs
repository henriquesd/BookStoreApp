using BookStoreApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // Task<IEnumerable<Book>> GetBooksByCategory(Guid categoryId);
    }
}
