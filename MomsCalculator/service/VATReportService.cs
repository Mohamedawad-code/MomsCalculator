using MomsCalculator.Interfaces;
using MomsCalculator.Models;
using MomsCalculator.Models.Enums;
using MomsCalculator.service;



namespace MomsCalculator.service
{
    public class VATReportService
    {
        public readonly ITransactionRepo _repo;

        public VATReportService(ITransactionRepo repo)
        {
            _repo = repo;
        }

        public VATReport ShowTotalReport(DateTime from, DateTime to)
        {
            if (from > to)
                throw new ArgumentException("From date must be on or before the To date");

            List<Transaction> transactions = _repo.GetByDateRange(from, to);

            double totalSalesVAT = transactions
                .Where(t => t.Type == ExpenseOrIncomeEnum.SaleInDk)
                .Sum(t => t.VATamount); // we fetch transactions with label saleInDK

            double totalPurchaseVAT = transactions
               .Where(t => t.Type == ExpenseOrIncomeEnum.PurchaseInDk)
               .Sum(t => t.VATamount); // we fetch transactions with label purchaseInDK

            double totalExportAmount = transactions
                .Where(t => t.Type == ExpenseOrIncomeEnum.Export)
                .Sum(t => t.Amount);

            double totalVAT = totalSalesVAT - totalPurchaseVAT;

            VATReport finalReport = new VATReport();

            finalReport.From = from;
            finalReport.To = to;
            finalReport.SalesVAT = totalSalesVAT;
            finalReport.PurchaseVAT = totalPurchaseVAT;
            finalReport.ExportValue = totalExportAmount;
            finalReport.TotalVAT = totalVAT;

            return finalReport;


        }

    }
}
