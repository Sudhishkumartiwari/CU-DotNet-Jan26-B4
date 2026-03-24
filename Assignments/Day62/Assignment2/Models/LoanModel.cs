using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day62.Assignment2.Models;

public class Loan
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? BorrowerName { get; set; } = string.Empty;
    [Precision(18, 2)]
    public decimal Amount { get; set; }
    public int LoanTermMonths {get;set;}
    public bool IsApproved { get; set; }
}