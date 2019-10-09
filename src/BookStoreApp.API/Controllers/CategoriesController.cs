using AutoMapper;
using BookStoreApp.API.Dtos;
using BookStoreApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository,
                                    IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        //public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        //{
        //    var categories = _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetCategories());
        //    return Ok(categories);
        //}

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAll());
            return categories;
        }
    }
}