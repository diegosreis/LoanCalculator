using LoanCalculator.Application.DTOs;
using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Services;

namespace LoanCalculator.Application.Services;

public class LoanApplicationService : ILoanApplicationService
{
    private readonly ILoanCalculator _loanCalculator;

    public LoanApplicationService(ILoanCalculator loanCalculator)
    {
        _loanCalculator = loanCalculator;
    }

    public PaymentPlanResult ProcessLoanApplication(LoanRequest loanRequest)
    {
        var loan = new Loan(
            loanRequest.Amount,
            loanRequest.PaybackTimeInYears,
            loanRequest.Type
        );

        var paymentPlan = _loanCalculator.CalculatePaymentPlan(loan);

        var paymentPlanResult = MapToPaymentPlanResult(paymentPlan, loan);
        return paymentPlanResult;
    }

    private PaymentPlanResult MapToPaymentPlanResult(PaymentPlan paymentPlan, Loan loan)
    {
        var paymentPlanResult = new PaymentPlanResult
        {
            LoanAmount = loan.Amount,
            PaybackTimeInYears = loan.PaybackTimeInYears,
            MonthlyPayments = paymentPlan.Payments.Select(payment => new MonthlyPaymentDetail
            {
                Month = payment.Month,
                PrincipalPayment = Math.Round(payment.PrincipalAmount, 2),
                InterestPayment = Math.Round(payment.InterestAmount, 2)
            }).ToList(),
            TotalPaid = paymentPlan.TotalPaid,
            TotalInterest = paymentPlan.TotalInterest
        };

        return paymentPlanResult;
    }
}