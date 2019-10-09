using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Add(Category category)
        {
            if (_categoryRepository.Search(c => c.Description == category.Description).Result.Any())
                return false;

            await _categoryRepository.Add(category);
            return true;
        }

        public async Task<bool> Update(Category category)
        {
            if (_categoryRepository.Search(c => c.Description == category.Description && c.Id != category.Id).Result.Any())
                return false;

            await _categoryRepository.Update(category);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            // if (_categoryRepository.GetBooksByCategory(id).Result.Any()) return false;

            //var category = await _categoryRepository.GetById(id);

            //if (category != null)
            //{
            //    await _categoryRepository.Remove(id);
            //}

            await _categoryRepository.Remove(id);

            return true;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
