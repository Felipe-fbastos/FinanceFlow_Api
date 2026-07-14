using FinanceFlowAPI.Data;
using FinanceFlowAPI.DTO;
using FinanceFlowAPI.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceFlowAPI.Service
{
    public class UserService
    {
        public readonly TokenService _tokenService;
        public readonly AppDataContext _context;

        public UserService(TokenService tokenService, AppDataContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        
        public async Task<UserGetDTO> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException($"User found with id {id}");
            }

            return user.Adapt<UserGetDTO>();
        }

        public async Task<IEnumerable<UserGetDTO>> GetAllAsync()
        {
            var users = await _context.Users
                .AsNoTracking()
                .ToListAsync();
                
            if (users.Count == 0)
            {
                throw new NotFoundException("No users found");
            }

            return users.Adapt<IEnumerable<UserGetDTO>>();
        }
    }
}
