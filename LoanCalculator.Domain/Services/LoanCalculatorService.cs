using LoanCalculator.Domain.Entities;

namespace LoanCalculator.Domain.Services;

public class LoanCalculatorService : ILoanCalculator
{
    public PaymentPlan CalculatePaymentPlan(Loan loan)
    {
        var payments = new List<Payment>();
        var paybackTimeInMonths = loan.PaybackTimeInYears * 12;

        var monthlyInterestRate = loan.InterestRate / 12 / 100;
        var monthlyPrincipalPayment = loan.Amount / paybackTimeInMonths;
        var totalInterestPaid = 0m;
        var totalPaid = 0m;

        for (var month = 1; month <= paybackTimeInMonths; month++)
        {
            var interestPayment = monthlyPrincipalPayment * paybackTimeInMonths * monthlyInterestRate;
            totalInterestPaid += interestPayment;
            var totalPayment = monthlyPrincipalPayment + interestPayment;
            totalPaid += totalPayment;
            payments.Add(new Payment(month, monthlyPrincipalPayment, interestPayment));
        }

        return new PaymentPlan(payments, totalPaid, totalInterestPaid);
    }
}