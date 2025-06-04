using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableCopies { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalCopies { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        // Foreign keys
        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        [Range(0, 5000)]
        public int PageCount { get; set; }

        // Navigation properties
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();

        // Status property
        public bool IsAvailable => AvailableCopies > 0;
    }
} 