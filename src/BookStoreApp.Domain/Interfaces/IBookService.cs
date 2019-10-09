using BookStoreApp.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Interfaces
{
    public interface IBookService
    {
        Task<bool> Add(Book book);
        Task<bool> Update(Book book);
        Task<bool> Remove(Guid id);
    }
}
