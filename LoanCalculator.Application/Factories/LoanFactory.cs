using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Enums;
using LoanCalculator.Domain.Interfaces;


namespace LoanCalculator.Application.Factories
{
    public class LoanFactory : ILoanFactory
    {
        public ILoan GetLoan(LoanType loanType)
        {
            return loanType switch
            {
                LoanType.House => new HouseLoan(),
                _ => throw new ArgumentException("Invalid loan type."),
            };
        }
    }
}
