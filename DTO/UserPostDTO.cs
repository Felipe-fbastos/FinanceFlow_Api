namespace FinanceFlowAPI.DTO
{
    public class UserPostDTO
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
