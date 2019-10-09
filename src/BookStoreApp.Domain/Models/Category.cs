using System.Collections.Generic;

namespace BookStoreApp.Domain.Models
{
    public class Category : Entity
    {
        public string Description { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}