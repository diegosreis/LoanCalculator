namespace LoanCalculator.Domain.Entities;

public class PaymentPlan
{
    public PaymentPlan(List<Payment> payments, decimal totalPaid, decimal totalInterest)
    {
        Payments = payments ?? throw new ArgumentNullException(nameof(payments));
        TotalPaid = totalPaid;
        TotalInterest = totalInterest;
    }

    public List<Payment> Payments { get; }
    public decimal TotalPaid { get; }
    public decimal TotalInterest { get; }
}

public class Payment
{
    public Payment(int month, decimal principalAmount, decimal interestAmount)
    {
        Month = month;
        PrincipalAmount = principalAmount;
        InterestAmount = interestAmount;
    }

    public int Month { get; }
    public decimal PrincipalAmount { get; }
    public decimal InterestAmount { get; }
    public decimal TotalAmount => Math.Round(PrincipalAmount + InterestAmount, 2);
}