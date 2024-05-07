using LoanCalculator.Domain.Interfaces;

namespace LoanCalculator.Domain.Entities
{
    public class HouseLoan: ILoan
    {
        public decimal GetInterest()
        {
            return 0.035m;
        }
    }
}
