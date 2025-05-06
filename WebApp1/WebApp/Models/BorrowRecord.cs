using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class BorrowRecord
    {
        public int BorrowRecordId { get; set; }
        
        public int BookId { get; set; }
        
        public int UserId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
        
        public bool IsReturned => ReturnDate.HasValue;
        
        public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        // Navigation properties
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
} 