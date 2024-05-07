using LoanCalculator.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Application.DTOs;

public class LoanRequest
{
    [Required(ErrorMessage = "The amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "The amount must be greater than 0.")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "The loan type is required.")]
    public LoanType LoanType { get; set; }

    [Required(ErrorMessage = "The payback scheme type is required.")]
    public PaybackSchemeType PaybackSchemeType { get; set; }

    [Required(ErrorMessage = "The duration is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "The duration must be greater than 0.")]
    public int Duration { get; set; }
}