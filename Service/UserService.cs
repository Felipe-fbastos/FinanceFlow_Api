using FinanceFlowAPI.Data;
using FinanceFlowAPI.DTO;
using FinanceFlowAPI.Exceptions;
using FinanceFlowAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceFlowAPI.Service
{
    public class UserService
    {
        public readonly TokenService _tokenService;
        public readonly AppDataContext _context;
        public readonly PasswordHasher<string> _passwordHasher;

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

        public async Task<UserPostDTO> CreateAsync(UserPostDTO dto)
        {
            bool existEmail = await _context.Users.AnyAsync(e => e.Email == dto.Email);

            if (existEmail)
            {
                throw new ConflictException("Email or password incorret");
            }

            var user = dto.Adapt<User>();

            user.PasswordHash = _passwordHasher.HashPassword(null, dto.PasswordHash);

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _context.Add(user);

            await _context.SaveChangesAsync();

            return user.Adapt<UserPostDTO>();
        }

        public async Task<string> LoginAsync(UserLoginDTO dto)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == dto.Email && e.IsActive);

            if(user == null)
            {
                throw new NotFoundException("Email or password invalid");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.PasswordHash);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new UnAuthotizedException("Email or password invalid");
            }

            return _tokenService.GenerateToken(user);
        }
    }
}
