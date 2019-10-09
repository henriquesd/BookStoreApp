using AutoMapper;
using BookStoreApp.API.Dtos;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
