using MomsCalculator.Models.Enums;

namespace MomsCalculator.Models
{
    public class VATResult
    {
       public double OriginalAmount { get; set; }
       public CountryEnum Country { get; set; }
       public ValutaEnum Valuta { get; set; }
       public VatDirectionEnum Direction { get; set; }
       public double FinalAmount { get; set; }



    }
}
