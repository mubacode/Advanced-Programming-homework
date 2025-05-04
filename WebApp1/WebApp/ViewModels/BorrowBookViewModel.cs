using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class BorrowBookViewModel
    {
        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "Book")]
        public int BookId { get; set; }
        
        [Required]
        [Display(Name = "Borrow Date")]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        
        [Required]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
        
        [Display(Name = "Notes")]
        [StringLength(500)]
        public string Notes { get; set; }
    }
} 