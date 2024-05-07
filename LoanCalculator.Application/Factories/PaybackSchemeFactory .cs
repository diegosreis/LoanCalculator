
using LoanCalculator.Domain.Enums;
using LoanCalculator.Domain.Interfaces;
using LoanCalculator.Domain.Services;



namespace LoanCalculator.Application.Factories
{
    public class PaybackSchemeFactory : IPaybackSchemeFactory
    {
        public IPaybackScheme GetPaybackScheme(PaybackSchemeType paybackSchemeType)
        {
            return paybackSchemeType switch
            {
                PaybackSchemeType.Monthly => new MonthlyPaybackScheme(),
                _ => throw new ArgumentException("Invalid payback scheme type."),
            };
        }
    }
}
