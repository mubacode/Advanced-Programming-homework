using System;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class LoanViewModel
    {
        public int BorrowRecordId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public bool IsOverdue { get; set; }
        public string Notes { get; set; }
    }
} 