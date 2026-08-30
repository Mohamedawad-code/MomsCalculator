using MomsCalculator.Models;
namespace MomsCalculator.service
{
    public class CalculatorService
    {
        
        public VATResult AddMoms(double price, Item item)
        {
            VATResult _result = new VATResult();
            price = item.Beforeprice;

          
            _result.AfterPrice = price + (price*(0.25));

            return _result;

        }
    }
} 
