using AutoMapper;
using BookStoreApp.API.Dtos;
using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository,
                                    IMapper mapper,
                                    ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAll());
            return categories;
        }

        [HttpGet("{id:guid}")]
        public async Task<CategoryDto> GetById(Guid id)
        {
            var category = _mapper.Map<CategoryDto>(await _categoryRepository.GetById(id));
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Add(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryDto);
            var result = await _categoryService.Add(category);

            if (!result) return BadRequest();

            return Ok(category);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> Update(Guid id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return Ok(categoryDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoryDto>> Remove(Guid id)
        {
            //var books = await _categoryRepository.GetBooksByCategory(id);
            //if (books != null) return BadRequest("Is not possible delete this category because it is being used");

            await _categoryService.Remove(id);

            return Ok();
        }
    }
}