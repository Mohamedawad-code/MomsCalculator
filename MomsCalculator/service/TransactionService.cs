using MomsCalculator.Models;
using MomsCalculator.Models.Enums;
using MomsCalculator.Repo;
using MomsCalculator.Interfaces;

namespace MomsCalculator.service
{
    public class TransactionService

    {
        public readonly ITransactionRepo _repo;

        public TransactionService(ITransactionRepo repo)
        {
            _repo = repo;
        }

        public Transaction CreateTransaction(string name, double amount, ExpenseOrIncomeEnum type, byte[]? imageData)
        {
            Transaction _transaction = new Transaction();

            _transaction.Name = name;
            _transaction.Amount = amount;
            _transaction.Type = type;
            _transaction.VATamount = AddVAT(amount);
            _transaction.ImageData = imageData;

            return _repo.Add(_transaction);

        }

        public double AddVAT(double amount)
        {
            double VATresult = amount * 0.25;
            return VATresult;

        }

        public Transaction EditTransaction(string name, double amount, ExpenseOrIncomeEnum type, byte[]? imageData, Guid id)
        {
            Transaction _transaction = _repo.GetById(id);

            _transaction.Name = name;
            _transaction.Amount = amount;
            _transaction.Type = type;
            _transaction.VATamount = AddVAT(amount);
            _transaction.ImageData = imageData;

            return _repo.Update(_transaction);
        }


    }
}
