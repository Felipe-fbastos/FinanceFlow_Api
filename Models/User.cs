namespace FinanceFlowAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public List<BankAccount> BankAccounts { get; set; }

        public void SoftDelete()
        {
            IsActive = false;
        }
    }
}

