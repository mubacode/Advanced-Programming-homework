using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(500)]
        public string Biography { get; set; }

        // Navigation property
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        // Computed property for full name
        public string FullName => $"{FirstName} {LastName}";
    }
} 