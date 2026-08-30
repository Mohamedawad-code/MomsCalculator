using MomsCalculator.Models;
using MomsCalculator.Models.Enums;
namespace MomsCalculator.service
{
    public class CalculatorService
    {
        
       
        
        public VATResult CalculateMoms(double price, CountryEnum country, VatDirectionEnum direction)
        {
           VATResult _result = new VATResult();

            _result.OriginalAmount = price;
            
            double countryVAT = GetVATrate(country);

            if (direction == VatDirectionEnum.afterVAT)
                _result.FinalAmount = price + (price * (countryVAT));

            if (direction == VatDirectionEnum.BeforeVAT)
                _result.FinalAmount = price - (price * (countryVAT));

            

            return _result;

        }

        public double GetVATrate(CountryEnum country)
        {
            switch (country)
            {
                case CountryEnum.AT:
                    return 0.20;
                case CountryEnum.BE:
                    return 0.21;
                case CountryEnum.BG:
                    return 0.20;
                case CountryEnum.HR:
                    return 0.25;
                case CountryEnum.CY:
                    return 0.19;
                case CountryEnum.CZ:
                    return 0.21;
                case CountryEnum.DK:
                    return 0.25;
                case CountryEnum.EE:
                    return 0.22;
                case CountryEnum.FI:
                    return 0.24;
                case CountryEnum.FR:
                    return 0.20;
                case CountryEnum.DE:
                    return 0.19;
                case CountryEnum.GR:
                    return 0.24;
                case CountryEnum.HU:
                    return 0.27;
                case CountryEnum.IE:
                    return 0.23;
                case CountryEnum.IT:
                    return 0.22;
                case CountryEnum.LV:
                    return 0.21;
                case CountryEnum.LT:
                    return 0.21;
                case CountryEnum.LU:
                    return 0.17;
                case CountryEnum.MT:
                    return 0.18;
                case CountryEnum.NL:
                    return 0.21;
                case CountryEnum.PL:
                    return 0.23;
                case CountryEnum.PT:
                    return 0.23;
                case CountryEnum.RO:
                    return 0.19;
                case CountryEnum.SK:
                    return 0.20;
                case CountryEnum.SI:
                    return 0.22;
                case CountryEnum.ES:
                    return 0.21;
                case CountryEnum.SE:
                    return 0.25;
                case CountryEnum.GB:
                    return 0.20;
               

                default:
                    throw new Exception("Unknown country");
            }

        }
    }
} 
