

using LoanCalculator.Domain.Enums;

namespace LoanCalculator.Domain.Interfaces
{
    public interface IPaybackSchemeFactory
    {
        IPaybackScheme GetPaybackScheme(PaybackSchemeType paybackSchemeType);
    }
}
