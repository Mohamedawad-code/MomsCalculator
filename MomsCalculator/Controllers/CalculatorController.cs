using Microsoft.AspNetCore.Mvc;
using MomsCalculator.service;
using MomsCalculator.DTO;
using MomsCalculator.Models;

namespace MomsCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController :ControllerBase
    {
        private readonly CalculatorService _calculator;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculator = calculatorService;
        }

        [HttpPost("Moms")]
        public IActionResult CalculateMoms([FromBody] CalculateVatRequestDTO request)
        {
            VATResult result = _calculator.CalculateMoms(request.Amount, request.Country, request.Direction);
            return Ok(result);


        }

        [HttpPost("UsedMoms")]
        public IActionResult CalculateUsedMoms([FromBody]UsedResultDTO request)
        {
            UsedVATResult result = _calculator.CalculateUsedVAT(request.OriginalAmount, request.SellingAmount);
            return Ok(result);
        }




    }
}
