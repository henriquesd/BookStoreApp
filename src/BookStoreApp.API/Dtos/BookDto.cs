using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.Dtos
{
    public class BookDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Author { get; set; }

        [StringLength(350, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime PublishDate { get; set; }

        //public IEnumerable<BookDto> Books { get; set; }
    }
}
