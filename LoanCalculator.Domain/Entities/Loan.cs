using LoanCalculator.Domain.Enums;

namespace LoanCalculator.Domain.Entities;

public class Loan
{
    public Loan(decimal amount, int paybackTimeInYears, LoanType type)
    {
        Amount = amount;
        PaybackTimeInYears = paybackTimeInYears;
        Type = type;

        InterestRate = type switch
        {
            LoanType.House => 3.5m,
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unsupported loan type: {type}.")
        };
    }

    public decimal Amount { get; }
    public int PaybackTimeInYears { get; }
    public LoanType Type { get; }
    public decimal InterestRate { get; }
}