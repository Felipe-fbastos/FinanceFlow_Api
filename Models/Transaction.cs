using System.Diagnostics;

namespace FinanceFlowAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
