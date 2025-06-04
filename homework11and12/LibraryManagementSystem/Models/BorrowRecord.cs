using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public enum BorrowStatus
    {
        Active,
        Returned,
        Overdue
    }

    public class BorrowRecord
    {
        public int BorrowRecordId { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        public BorrowStatus Status { get; set; } = BorrowStatus.Active;

        [StringLength(500)]
        public string Notes { get; set; }

        // Extension methods
        public int GetDaysOverdue()
        {
            if (Status == BorrowStatus.Returned)
                return 0;
                
            return DateTime.Now > DueDate 
                ? (int)(DateTime.Now - DueDate).TotalDays 
                : 0;
        }

        public decimal CalculateFine(decimal finePerDay = 0.50m)
        {
            int daysOverdue = GetDaysOverdue();
            return daysOverdue * finePerDay;
        }
    }
} 