using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.Infrastructure.Contexts;

namespace BookStoreApp.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookStoreAppContext context) : base(context) { }
    }
}