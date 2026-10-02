using MomsCalculator.Models;
using MomsCalculator.Models.Enums;

namespace MomsCalculator.service
{
    public class TransactionService
    {
        public Transaction CreateTransaction(string name, double amount, ExpenseOrIncomeEnum type)
        {
            Transaction _transaction = new Transaction();

            _transaction.Name = name;
            _transaction.Amount = amount;
            _transaction.Type = type;
            _transaction.VATamount = 

            return _transaction;

        }
    }
}
