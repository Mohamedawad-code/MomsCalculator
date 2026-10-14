using MomsCalculator.Models.Enums;

namespace MomsCalculator.DTO
{
    public class TransactionDTO
    {
        public string? Name { get; set; }
        public double Amount { get; set; }
        public ExpenseOrIncomeEnum Type { get; set; }
        public byte[]? ImageData { get; set; }
        public DateTime SettingDate { get; set; } = DateTime.UtcNow.Date;
        

    }
}
