using Microsoft.AspNetCore.Mvc;
using MomsCalculator.service;
using MomsCalculator.DTO;
using MomsCalculator.Models;
using MomsCalculator.Interfaces;
using MomsCalculator.Models.Enums;

namespace MomsCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController :ControllerBase
    {
        private readonly TransactionService _transactionService;
       

        public TransactionController(ITransactionRepo transactionRepo, TransactionService transactionService)
        {
            
            _transactionService = transactionService;
        }


        [HttpGet]
        public IActionResult GetAllTransactions(DateTime? from, DateTime? to, ExpenseOrIncomeEnum? type, string? name)
        {
            try
            {
                List<Transaction> result = _transactionService.SearchTransactions(from, to, type, name);
                return Ok(result);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTransactionById(Guid id)
        {
            Transaction? result = _transactionService.GetTransactionById(id);
            if (result == null)
                return NotFound();

            return Ok(result);

        }
        
        
        
        [HttpPost]
        public IActionResult CreateTransaction([FromBody]TransactionDTO request)
        {
            try
            {

                Transaction result = _transactionService.CreateTransaction(
                    request.Name,
                    request.Amount,
                    request.Type,
                    request.ImageData,
                    request.SettingDate);

                return Ok(result);
            }

            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaction(Guid id, [FromBody]TransactionDTO request)
        {

            try
            {
                Transaction? result = _transactionService.EditTransaction(request.Name,
                    request.Amount,
                    request.Type,
                    request.ImageData,
                    id,
                    request.SettingDate);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }

            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(Guid id)
        {
            bool result = _transactionService.DeleteTransaction(id);
            if (result == false)
                return NotFound();

            return NoContent();
        }






    }
}
