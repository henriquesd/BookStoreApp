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
    public class BooksController : MainController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository,
                                IMapper mapper,
                                IBookService bookService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookService = bookService;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetAll());
            return books;
        }

        [HttpGet("{id:guid}")]
        public async Task<BookDto> GetById(Guid id)
        {
            var book = _mapper.Map<BookDto>(await _bookRepository.GetById(id));
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Add(BookDto bookDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var book = _mapper.Map<Book>(bookDto);
            var result = await _bookService.Add(book);

            if (!result) return BadRequest();

            return Ok(book);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BookDto>> Update(Guid id, BookDto bookDto)
        {
            if (id != bookDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _bookService.Update(_mapper.Map<Book>(bookDto));

            return Ok(bookDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BookDto>> Remove(Guid id)
        {
            //var bookDto = await _bookRepository.GetById(id);

            //if (bookDto == null) return NotFound();

            await _bookService.Remove(id);

            return Ok();
        }
    }
}