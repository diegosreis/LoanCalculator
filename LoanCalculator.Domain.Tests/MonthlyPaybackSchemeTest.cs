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
            var loanAmount = 10000m;
            var duration = 2; // in years
            var loan = new HouseLoan();
            

            var monthlyPaybackScheme = new MonthlyPaybackScheme();

            // Act
            var paymentPlan = monthlyPaybackScheme.GeneratePaymentPlan(loanAmount, duration, loan);

            // Assert
            Assert.NotNull(paymentPlan);
            Assert.IsType<PaymentPlan>(paymentPlan);
            Assert.Equal(24, paymentPlan.Payments.Count); // Should be 24 payments for 2 year
            Assert.Equal(Math.Round(10700m, 2), Math.Round(paymentPlan.TotalPaid,2));

        }
    }
}