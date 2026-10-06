using System;
using System.Collections.Generic;
using MomsCalculator.Models;
using MomsCalculator.Interfaces;

namespace MomsCalculator.Repo
{
    public class InMemoryTransactionRepo : ITransactionRepo
    {
        private List<Transaction> _list = new List<Transaction>();

        public Transaction Add(Transaction transaction)
        {
            _list.Add(transaction);
            return transaction;
        }

        public Transaction? GetById(Guid id)
        {
            Transaction? found = _list.FirstOrDefault(f => f.ID == id);
            return found;
        }

        public List<Transaction> GetAll()
        {
            return _list;
        }

        public Transaction? Update(Transaction transaction)
        {
            Transaction current = _list.FirstOrDefault(f => f.ID == transaction.ID);
            current.Name = transaction.Name;
            current.ImageData = transaction.ImageData;
            current.Amount = transaction.Amount;

            return current;
            
            
            
        }

        public bool Delete(Guid id)
        {
            Transaction? found = _list.FirstOrDefault(f => f.ID == id);

            if (found == null)
                return false;

            _list.Remove(found);

          

            return true;
        }
    }
}
