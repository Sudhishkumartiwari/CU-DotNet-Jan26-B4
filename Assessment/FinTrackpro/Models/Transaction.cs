using System;
using System.ComponentModel.DataAnnotations;

namespace FinTrackpro.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime Date { get; set; }

        public int AccountId { get; set; }

        public Account? Account { get; set; }
    }

}
