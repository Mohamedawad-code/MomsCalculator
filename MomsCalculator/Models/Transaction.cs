using MomsCalculator.Models.Enums;

namespace MomsCalculator.Models
{
    public class Transaction
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public double VATamount { get; set; }
        public ExpenseOrIncomeEnum Type { get; set; }


    }
}
