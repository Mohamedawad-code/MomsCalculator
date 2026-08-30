using MomsCalculator.Models.Enums;
namespace MomsCalculator.DTO

{
    public class CalculateVatRequestDTO
    {
        public double Amount { get; set; }
        public CountryEnum Country { get; set; }
        public ValutaEnum Valuta { get; set; }
        public VatDirectionEnum Direction { get; set; }
    }
}
