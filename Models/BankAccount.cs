
namespace FinanceFlowAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Type { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; } 
        public bool IsActive { get; set; } = true;
        public List<Transaction> Transactions { get; set; } = new();
        public void SoftDelete()
        {
            IsActive = false;
        }
    }
}
