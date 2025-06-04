using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int AvailableCopies { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
} 