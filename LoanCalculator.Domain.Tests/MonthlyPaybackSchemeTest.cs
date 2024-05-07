using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Services;


namespace LoanCalculator.Tests.Domain.Services
{
    public class MonthlyPaybackSchemeTest
    {
        [Fact]
        public void GeneratePaymentPlan_ReturnsExpectedPaymentPlan()
        {
            // Arrange
            var loanAmount = 1000m;
            var duration = 1; // in years
            var loan = new HouseLoan();
            

            var monthlyPaybackScheme = new MonthlyPaybackScheme();

            // Act
            var paymentPlan = monthlyPaybackScheme.GeneratePaymentPlan(loanAmount, duration, loan);

            // Assert
            Assert.NotNull(paymentPlan);
            Assert.IsType<PaymentPlan>(paymentPlan);
            Assert.Equal(12, paymentPlan.Payments.Count); // Should be 12 payments for 1 year

        }
    }
}