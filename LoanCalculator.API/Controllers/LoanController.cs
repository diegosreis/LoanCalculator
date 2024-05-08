using System.Text;
using System.Xml.Serialization;
using LoanCalculator.Application.DTOs;
using LoanCalculator.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanApplicationService _loanApplicationService;

    public LoanController(ILoanApplicationService loanApplicationService)
    {
        _loanApplicationService = loanApplicationService;
    }

    [HttpGet("calculate-loan")]
    public ActionResult<PaymentPlanResult> CalculateLoan([FromQuery] LoanRequest loanRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var paymentPlanResult = _loanApplicationService.ProcessLoanApplication(loanRequest);
        return Ok(paymentPlanResult);
    }

    [HttpGet("calculate-loan-xml")]
    public ActionResult CalculateLoanXml([FromQuery] LoanRequest loanRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var paymentPlanResult = _loanApplicationService.ProcessLoanApplication(loanRequest);

        var xmlSerializer = new XmlSerializer(typeof(PaymentPlanResult));
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, paymentPlanResult);
        var xmlContent = stringWriter.ToString();

        return Content(xmlContent, "application/xml", Encoding.UTF8);
    }
}