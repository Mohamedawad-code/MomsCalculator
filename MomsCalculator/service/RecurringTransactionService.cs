using MomsCalculator.Models;
using MomsCalculator.Models.Enums;
using MomsCalculator.Interfaces;
using MomsCalculator.Models;

namespace MomsCalculator.service
{
    public class RecurringTransactionService
    {
        private readonly IRepoRecurringTransaction _repo;
        private readonly TransactionService _transactionService;

        public RecurringTransactionService(IRepoRecurringTransaction repo, TransactionService transactionService)
        {
            _repo = repo;
            _transactionService = transactionService;
        }

        public DateTime GetDueDate(int year, int month, int dayOfMonth)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int actualDay = Math.Min(dayOfMonth, daysInMonth);
            return new DateTime(year, month, actualDay);
        }

        public RecurringTransaction CreateRecurring(Guid transactionId, TransactionFrequency frequency, int dayOfMonth, DateTime startDate, DateTime? endDate)
        {
            if (_transactionService.GetTransactionById(transactionId) == null)
                throw new ArgumentException("The original transaction does not exist.");
            if (dayOfMonth < 1 || dayOfMonth > 31)
                throw new ArgumentException("Day of month must be between 1 and 31.");
            if (endDate.HasValue && endDate.Value < startDate)
                throw new ArgumentException("End date cannot be before start date.");


            RecurringTransaction recurringTransaction = new RecurringTransaction
            {
                TransactionId = transactionId,
                Frequency = frequency,
                DayOfMonth = dayOfMonth,
                StartDate = startDate,
                EndDate = endDate,
                NextDueDate = GetDueDate(startDate.Year, startDate.Month, dayOfMonth)
            };

            return _repo.Add(recurringTransaction);
        }





    }
} 
