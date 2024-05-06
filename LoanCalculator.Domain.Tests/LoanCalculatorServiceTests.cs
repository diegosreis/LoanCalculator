using LoanCalculator.Domain.Entities;
using LoanCalculator.Domain.Enums;
using LoanCalculator.Domain.Services;

namespace LoanCalculator.Domain.Tests;

public class LoanCalculatorServiceTests
{
    [Fact]
    public void CalculatePaymentPlan_ShouldReturnValidPaymentPlan_GivenValidLoan()
    {
        // Arrange
        var loanCalculatorService = new LoanCalculatorService();
        var loan = new Loan(10000m, 2, LoanType.House);

        // Act
        var paymentPlan = loanCalculatorService.CalculatePaymentPlan(loan);

        var originalAmount = Math.Round(paymentPlan.TotalPaid - paymentPlan.TotalInterest, 2);
        // Assert
        Assert.NotNull(paymentPlan);
        Assert.Equal(24, paymentPlan.Payments.Count);
        Assert.Equal(originalAmount, loan.Amount);
    }
}