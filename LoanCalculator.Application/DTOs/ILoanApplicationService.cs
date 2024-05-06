namespace LoanCalculator.Application.DTOs;

public interface ILoanApplicationService
{
    PaymentPlanResult ProcessLoanApplication(LoanRequest loanRequest);
}