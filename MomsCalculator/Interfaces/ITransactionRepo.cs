using MomsCalculator.Models;

namespace MomsCalculator.Interfaces
{
    public interface ITransactionRepo
    {
        Transaction Add(Transaction transaction);
        Transaction? GetById(Guid id);
        List<Transaction> GetAll();
        Transaction? Update(Transaction transaction);
        bool Delete(Guid id);
    }
}
