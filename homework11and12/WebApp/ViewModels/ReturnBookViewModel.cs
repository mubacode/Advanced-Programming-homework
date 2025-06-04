using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ReturnBookViewModel
    {
        public int BorrowRecordId { get; set; }
        
        [Display(Name = "Book")]
        public string BookTitle { get; set; }
        
        [Display(Name = "User")]
        public string UserName { get; set; }
        
        [Display(Name = "Borrow Date")]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }
        
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        
        [Required]
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        
        [Display(Name = "Notes")]
        [StringLength(500)]
        public string Notes { get; set; }
        
        public bool IsOverdue => DateTime.Now > DueDate;
    }
} 