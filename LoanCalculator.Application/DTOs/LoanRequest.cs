using LoanCalculator.Domain.Enums;

namespace LoanCalculator.Application.DTOs;

public class LoanRequest
{
    public decimal Amount { get; set; }
    public LoanType LoanType { get; set; }

    public PaybackSchemeType PaybackSchemeType { get; set; }

    public int Duration { get; set; }
}