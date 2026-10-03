using MomsCalculator.Models;
using MomsCalculator.Models.Enums;

namespace MomsCalculator.service
{
    public class TransactionService
    {
        public Transaction CreateTransaction(string name, double amount, ExpenseOrIncomeEnum type, byte[]? imageData)
        {
            Transaction _transaction = new Transaction();

            _transaction.Name = name;
            _transaction.Amount = amount;
            _transaction.Type = type;
            _transaction.VATamount = AddVAT(amount);
            _transaction.ImageData = imageData;

            return _transaction;

        }

        public double AddVAT(double amount)
        {
            double VATresult = amount * 0.25;
            return VATresult;

        }

        public Transaction EditTransaction(string name, double amount, ExpenseOrIncomeEnum type, byte[]? imageData)
        {

        }


    }
}
