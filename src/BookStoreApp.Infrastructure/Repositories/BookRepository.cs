using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreAppContext context) : base(context) { }

        public async Task<Book> GetBookCategory(Guid id)
        {
            return await Db.Books.AsNoTracking().Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
       
        public async Task<IEnumerable<Book>> GetBooksCategories()
        {
            return await Db.Books.AsNoTracking().Include(c => c.Category)
                .OrderBy(b => b.Name).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(Guid categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }
    }
}