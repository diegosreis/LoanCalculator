using LoanCalculator.Application.DTOs;
using LoanCalculator.Application.Interfaces;
using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Interfaces;

namespace LoanCalculator.Application.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        
        private readonly IPaybackSchemeFactory _paybackSchemeFactory;
        private readonly ILoanFactory _loanFactory;

        public LoanApplicationService(IPaybackSchemeFactory paybackSchemeFactory, ILoanFactory loanFactory)
        {
            _paybackSchemeFactory = paybackSchemeFactory;
            _loanFactory = loanFactory;
        }

        public PaymentPlanResult ProcessLoanApplication(LoanRequest loanRequest)
        {
            
            var loan = _loanFactory.GetLoan(loanRequest.LoanType);

            
            var paybackScheme = _paybackSchemeFactory.GetPaybackScheme(loanRequest.PaybackSchemeType);

            var paymentPlan = paybackScheme.GeneratePaymentPlan(loanRequest.Amount,
                loanRequest.Duration, loan);

            
            var paymentPlanResult = MapToPaymentPlanResult(paymentPlan, loanRequest);
            return paymentPlanResult;
        }

        private PaymentPlanResult MapToPaymentPlanResult(PaymentPlan paymentPlan, LoanRequest loanRequest)
        {
            var paymentPlanResult = new PaymentPlanResult
            {
                LoanAmount = loanRequest.Amount,
                PaybackTimeInYears = loanRequest.Duration,
                Payments = paymentPlan.Payments.Select(payment => new PaymentsDetail
                {
                    PaymentNumber = payment.PaymentNumber,
                    PrincipalPayment = Math.Round(payment.PrincipalAmount, 2),
                    InterestPayment = Math.Round(payment.InterestAmount, 2)
                }).ToList(),
                TotalPaid = paymentPlan.TotalPaid,
                TotalInterest = paymentPlan.TotalInterest
            };

            return paymentPlanResult;
        }
    }
}