namespace FinanceFlowAPI.DTO.Category
{
    public class CategoryGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
