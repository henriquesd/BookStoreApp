using BookStoreApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task Add(Category category);
        Task Update(Category category);
        Task Remove(Guid id);
    }
}
