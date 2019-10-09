using BookStoreApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<bool> Add(Category category);
        Task<bool> Update(Category category);
        Task<bool> Remove(Guid id);
    }
}
