using LoanCalculator.Domain.Enums;

namespace LoanCalculator.Application.DTOs;

public class LoanRequest
{
    public decimal Amount { get; set; }
    public int PaybackTimeInYears { get; set; }
    public LoanType Type { get; set; }
}