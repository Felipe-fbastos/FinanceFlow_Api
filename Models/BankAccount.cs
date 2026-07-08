namespace FinanceFlowAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int IdCategories { get; set; }
        public List<Category> Categories { get; set; } = new();
        public string Name { get; set; } = null!;
        public string Type { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public void SoftDelete()
        {
            IsActive = false;
        }
    }
}
