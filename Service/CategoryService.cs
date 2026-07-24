using FinanceFlowAPI.Data;
using FinanceFlowAPI.DTO.Category;
using FinanceFlowAPI.Exceptions;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FinanceFlowAPI.Service
{
    public class CategoryService
    {
        private readonly AppDataContext _context;

        public CategoryService(AppDataContext context)
        {
            _context = context;
        }

        public async Task<CategoryGetDTO> GetByIdAsync(int id)
        {
            var cate = await _context.BankAccounts
                .AsTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cate == null)
            {
                throw new NotFoundException("Category not found");
            }

            return cate.Adapt<CategoryGetDTO>();
        }

        public async Task<IEnumerable<CategoryGetDTO>> GetAllAsync()
        {
            var cate = await _context.BankAccounts
                .AsTracking()
                .ToListAsync();

            if (cate.Count == 0)
            {
                throw new NotFoundException("No categories found");
            }

            return cate.Adapt<IEnumerable<CategoryGetDTO>>();
        }

        public async Task<CategoryPostDTO> CreateAsync(CategoryPostDTO dto)
        {
            bool existName = await _context.Cate
        } 
    }
}
