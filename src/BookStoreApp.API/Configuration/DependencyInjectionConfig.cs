using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Infrastructure.Contexts;
using BookStoreApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApp.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BookStoreAppContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
