namespace FinanceFlowAPI.DTO
{
    public class UserLoginDTO
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
