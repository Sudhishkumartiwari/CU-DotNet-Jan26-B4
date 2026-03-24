using System.ComponentModel.DataAnnotations;
namespace QuickLoan.Models;

public class Loan
{
    public int Id {get;set;}
    [Display(Name = "Borrower Name")]
    public required string BorrowerName {get;set;}
    public string? LenderName {get;set;}
    [Range(1,500000)]
    public double Amount {get;set;}
    public bool IsSettled {get;set;}
}

