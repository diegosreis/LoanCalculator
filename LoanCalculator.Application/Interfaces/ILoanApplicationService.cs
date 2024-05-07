
using LoanCalculator.Application.DTOs;

namespace LoanCalculator.Application.Interfaces;

public interface ILoanApplicationService
{
    PaymentPlanResult ProcessLoanApplication(LoanRequest loanRequest);
}