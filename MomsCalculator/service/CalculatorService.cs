using MomsCalculator.Models;
namespace MomsCalculator.service
{
    public class CalculatorService
    {
        
        public Result AddMoms(double price, Item item)
        {
            Result _result = new Result();
            price = item.Beforeprice;

          
            _result.AfterPrice = price + (price*(0.25));

            return _result;

        }
    }
} 
