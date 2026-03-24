namespace Day62.Assignment2.DTOs;
public class LoanUpdateDto
{
    public string BorrowerName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public int LoanTermMonths { get; set; }
    public bool IsApproved { get; set; }
}