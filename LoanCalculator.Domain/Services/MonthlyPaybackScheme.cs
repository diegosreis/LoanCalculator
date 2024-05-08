using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Interfaces;

namespace LoanCalculator.Domain.Services
{
    public class MonthlyPaybackScheme : IPaybackScheme
    {
        public PaymentPlan GeneratePaymentPlan(decimal loanAmount, int duration, ILoan loan)
        {

            var payments = new List<Payment>();

            var paybackTimeInMonths = duration * 12;

            var interestRate = loan.GetInterest();

            var monthlyInterestRate = interestRate / 12;
            var monthlyPrincipalPayment = loanAmount / paybackTimeInMonths;
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
}