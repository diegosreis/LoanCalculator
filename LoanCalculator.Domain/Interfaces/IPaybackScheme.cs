using LoanCalculator.Domain.Entities;


namespace LoanCalculator.Domain.Interfaces
{
    public interface IPaybackScheme
    {
        
        PaymentPlan GeneratePaymentPlan(decimal loanAmount, int duration, ILoan loan);
    }
}
