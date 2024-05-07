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

