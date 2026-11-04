using MomsCalculator.Models.Enums;

namespace MomsCalculator.Models
{
    public class RecurringTransaction
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid TransactionId { get; set; } 
        public TransactionFrequency Frequency { get; set; }
        public int DayOfMonth { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime NextDueDate { get; set; }
    }
}
