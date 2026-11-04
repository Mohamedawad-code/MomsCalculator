using MomsCalculator.Models;

namespace MomsCalculator.Interfaces
{
    public interface IRepoRecurringTransaction
    {
        RecurringTransaction Add(RecurringTransaction recurringTransaction);
        RecurringTransaction? GetById(Guid id);
        List<RecurringTransaction> GetAll();
        RecurringTransaction? Update(RecurringTransaction recurringTransaction);
        bool Delete(Guid id);
    }
}
