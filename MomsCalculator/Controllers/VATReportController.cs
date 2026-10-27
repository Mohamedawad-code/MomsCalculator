using Microsoft.AspNetCore.Mvc;
using MomsCalculator.Models;
using MomsCalculator.service;

namespace MomsCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VATReportController : ControllerBase
    {
        private readonly VATReportService _reportService;

        public VATReportController(VATReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult GetVATReport(DateTime from, DateTime to)
        {
            try
            {
                VATReport report = _reportService.ShowTotalReport(from, to);
                return Ok(report);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}