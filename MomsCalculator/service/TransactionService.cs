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

        public Transaction CreateTransaction(string name, double amount, ExpenseOrIncomeEnum type, byte[]? imageData, DateTime settingDate)
        {
            Transaction _transaction = new Transaction();

            _transaction.Name = name;
            _transaction.Amount = amount;
            _transaction.Type = type;
            _transaction.VATamount = AddVAT(amount);
            _transaction.ImageData = imageData;
            _transaction.SettingDate = settingDate;

            return _repo.Add(_transaction);

        }

        public double AddVAT(double amount)
        {
            double VATresult = amount * 0.25;
            return VATresult;

        }

        public Transaction? EditTransaction(string name, double amount, ExpenseOrIncomeEnum type, byte[]? imageData, Guid id, DateTime settingDate)
        {
            Transaction? _transaction = _repo.GetById(id);

            if (_transaction == null)
                return null;

            _transaction.Name = name;
            _transaction.Amount = amount;
            _transaction.Type = type;
            _transaction.VATamount = AddVAT(amount);
            _transaction.ImageData = imageData;
            _transaction.SettingDate = settingDate;

            return _repo.Update(_transaction);
        }


        public bool DeleteTransaction(Guid id)
        {
           
            bool result = _repo.Delete(id);
            return result;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _repo.GetAll();
        }

        public Transaction? GetTransactionById(Guid id)
        {
            return _repo.GetById(id);
        }


    }
}
