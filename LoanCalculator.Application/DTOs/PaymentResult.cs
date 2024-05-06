using System.Xml.Serialization;

namespace LoanCalculator.Application.DTOs;

[XmlRoot("PaymentPlanResult")]
public class PaymentPlanResult
{
    [XmlElement("LoanAmount")] public decimal LoanAmount { get; set; }

    [XmlElement("PaybackTimeInYears")] public int PaybackTimeInYears { get; set; }

    [XmlArray("MonthlyPayments")]
    [XmlArrayItem("MonthlyPaymentDetail")]
    public List<MonthlyPaymentDetail> MonthlyPayments { get; set; } = null!;

    [XmlElement("TotalPaid")] public decimal TotalPaid { get; set; }

    [XmlElement("TotalInterest")] public decimal TotalInterest { get; set; }
}

public class MonthlyPaymentDetail
{
    [XmlElement("Month")] public int Month { get; set; }

    [XmlElement("PrincipalPayment")] public decimal PrincipalPayment { get; set; }

    [XmlElement("InterestPayment")] public decimal InterestPayment { get; set; }

    [XmlElement("TotalPayment")] public decimal TotalPayment => PrincipalPayment + InterestPayment;
}