namespace FinanceFlowAPI.DTO.BankAccount
{
    public class BankAccountPostDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
