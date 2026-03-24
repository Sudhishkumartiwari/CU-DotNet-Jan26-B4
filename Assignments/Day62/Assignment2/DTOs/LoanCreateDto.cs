using System.ComponentModel.DataAnnotations;
namespace Day62.Assignment2.DTOs;
public class LoanCreateDto
{
    [Required]
    public string BorrowerName { get; set; } = string.Empty;
    
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
    public decimal Amount { get; set; }
    
    [Range(1, 360)]
    public int LoanTermMonths { get; set; }
}