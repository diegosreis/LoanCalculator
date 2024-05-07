
namespace LoanCalculator.Domain.Entities
{
    public class Payment
    {
        public Payment(int paymentNumber, decimal principalAmount, decimal interestAmount)
        {
            PaymentNumber = paymentNumber;
            PrincipalAmount = principalAmount;
            InterestAmount = interestAmount;
        }

        public int PaymentNumber { get; }
        public decimal PrincipalAmount { get; }
        public decimal InterestAmount { get; }
        public decimal TotalAmount => Math.Round(PrincipalAmount + InterestAmount, 2);
    }
}
