using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookStoreAppContext context) : base(context) { }

        //public async Task<IEnumerable<Book>> GetBooksByCategory(Guid categoryId)
        //{
        //    return await Db.Books.AsNoTracking()
        //        .Include(b => b.Category)
        //        .ToListAsync();
        //}

        //public async Task<IEnumerable<Book>> GetBooksByCategory(Guid categoryId)
        //{
        //    //return await Db.Categories.AsNoTracking()
        //    //  .Include(c => c.Books)
        //    //  .ToListAsync();

        //    //return await Db.Books.AsNoTracking()
        //    //   .Include(c => c.Category)
        //    //   .ToListAsync(c => c.CategoryId == categoryId);
        //}
    }
}