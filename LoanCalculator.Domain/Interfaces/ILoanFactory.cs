using LoanCalculator.Domain.Enums;

namespace LoanCalculator.Domain.Interfaces
{
    public interface ILoanFactory
    {
        ILoan GetLoan(LoanType loanType);
    }
}
