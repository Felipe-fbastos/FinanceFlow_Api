using FinanceFlowAPI.Data;
using FinanceFlowAPI.DTO.BankAccount;
using FinanceFlowAPI.Exceptions;
using FinanceFlowAPI.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FinanceFlowAPI.Service
{
    public class BankAccountService
    {
        private readonly AppDataContext _context;

        public BankAccountService(AppDataContext context)
        {
            _context = context;
        }


        public async Task<BankAccountGetDTO> GetByIdAsync(int id)
        {
            var bank = await _context.BankAccounts.FindAsync(id);

            if (bank == null)
            {
                throw new NotFoundException("Bank Account not found");
            }

            return bank.Adapt<BankAccountGetDTO>();
        }

        public async Task<IEnumerable<BankAccountGetDTO>> GetAllAsync()
        {
            var bank = await _context.BankAccounts
                .AsNoTracking()
                .ToListAsync();

            if (bank.Count == 0)
            {
                throw new NotFoundException("Bank account not found");
            }

            return bank.Adapt<IEnumerable<BankAccountGetDTO>>();
        }

        public async Task<BankAccountPostDTO> CreateAsync(BankAccountPostDTO dto)
        {
            bool bankName = await _context.BankAccounts.AnyAsync(e => e.Name == dto.Name);

            if (bankName)
            {
                throw new ConflictException("This name already register"); 
            }

            var bank = dto.Adapt<BankAccount>();

            bank.CreatedAt = DateTime.UtcNow;
             
            await _context.SaveChangesAsync();

            return bank.Adapt<BankAccountPostDTO>();
        }

        public async Task UpdateAsync(int id, BankAccountPutDTO dto)
        {
            var bank = await _context.BankAccounts.FindAsync(id);

            if (bank == null)
            {
                throw new NotFoundException("Bank Account not found");
            }

            bool existName = await _context.BankAccounts.AnyAsync(e => e.Name == dto.Name && e.Id != id);

            if (existName)
            {
                throw new ConflictException("Name already register");
            }

            dto.Adapt(bank);

            bank.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bank = await _context.BankAccounts.FindAsync(id);

            if (bank == null)
            {
                throw new NotFoundException("Bank Account not found");
            }

            bank.SoftDelete();

            bank.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
