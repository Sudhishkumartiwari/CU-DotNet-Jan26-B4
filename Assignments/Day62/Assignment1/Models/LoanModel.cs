using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day62.Assignment1.Models;

public class Loan
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? BorrowerName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public int LoanTermMonths {get;set;}
    public bool IsApproved { get; set; }
}