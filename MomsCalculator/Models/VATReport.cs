namespace MomsCalculator.Models
{
    public class VATReport
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double PurchaseVAT { get; set; }
        public double SalesVAT { get; set; }
        public double ExportValue { get; set; }
        public double TotalVAT { get; set; }
    }
}
