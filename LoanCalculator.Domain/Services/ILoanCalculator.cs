using LoanCalculator.Domain.Entities;

namespace LoanCalculator.Domain.Services;

public interface ILoanCalculator
{
    PaymentPlan CalculatePaymentPlan(Loan loan);
}