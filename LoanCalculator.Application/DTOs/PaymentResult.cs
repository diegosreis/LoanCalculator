using System.Xml.Serialization;

namespace LoanCalculator.Application.DTOs;

[XmlRoot("PaymentPlanResult")]
public class PaymentPlanResult
{
    [XmlElement("LoanAmount")] public decimal LoanAmount { get; set; }
    [XmlElement("PaybackTimeInYears")] public decimal PaybackTimeInYears { get; set; }

    [XmlArray("Payments")]
    [XmlArrayItem("PaymentsDetail")]
    public List<PaymentsDetail> Payments { get; set; } = null!;

    [XmlElement("TotalPaid")] public decimal TotalPaid { get; set; }

    [XmlElement("TotalInterest")] public decimal TotalInterest { get; set; }
}

public class PaymentsDetail
{
    [XmlElement("PaymentNumber")] public int PaymentNumber { get; set; }

    [XmlElement("PrincipalPayment")] public decimal PrincipalPayment { get; set; }

    [XmlElement("InterestPayment")] public decimal InterestPayment { get; set; }

    [XmlElement("TotalPayment")] public decimal TotalPayment => PrincipalPayment + InterestPayment;
}