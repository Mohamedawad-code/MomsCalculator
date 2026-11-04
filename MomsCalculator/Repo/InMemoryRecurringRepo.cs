using System.Collections.Generic;
using MomsCalculator.Models;
using MomsCalculator.Interfaces;

namespace MomsCalculator.Repo
{
    public class InMemoryRecurringRepo : IRepoRecurringTransaction
    {
        private List<RecurringTransaction> _list = new List<RecurringTransaction>();

        public RecurringTransaction Add(RecurringTransaction recurringTransaction)
        {
            _list.Add(recurringTransaction);
            return recurringTransaction;
        }

        public RecurringTransaction? GetById(Guid id)
        {
            RecurringTransaction? found = _list.FirstOrDefault(f => f.TransactionId == id);
            return found;
        }

        public List<RecurringTransaction> GetAll()
        {
            return _list;
        }

        public RecurringTransaction? Update(RecurringTransaction recurringTransaction)
        {
            RecurringTransaction? current = _list.FirstOrDefault(f => f.TransactionId == recurringTransaction.TransactionId);

            if (current == null)
                return null;

            current.Frequency = recurringTransaction.Frequency;
            current.DayOfMonth = recurringTransaction.DayOfMonth;
            current.StartDate = recurringTransaction.StartDate;
            current.EndDate = recurringTransaction.EndDate;
            current.NextDueDate = recurringTransaction.NextDueDate;

            return current;
        }

        public bool Delete(Guid id)
        {
            RecurringTransaction? found = _list.FirstOrDefault(f => f.TransactionId == id);

            if (found == null)
                return false;

            _list.Remove(found);
            return true;
        }
    }
}
