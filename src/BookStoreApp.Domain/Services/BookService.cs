using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Add(Book book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name).Result.Any())
                return false;

            await _bookRepository.Add(book);
            return true;
        }

        public async Task<bool> Update(Book book)
        {
            if (_bookRepository.Search(b => b.Name == book.Name && b.Id != book.Id).Result.Any())
                return false;

            await _bookRepository.Update(book);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            //var book = await _bookRepository.GetById(id);

            //if (book != null)
            //{
            //    await _bookRepository.Remove(id);
            //}

            await _bookRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
        }
    }
}
