using ASPNETCoreWebAPI.Db;
using ASPNETCoreWebAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Services
{
    public class UserService : IUserService
    {

        // DI
        private readonly ASPNETCoreWebAPIDbContext _context;
        public UserService(ASPNETCoreWebAPIDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(IEnumerable<UserResponseDto> Users, int TotalCount)> GetAllAsync(UserQueryDto query)
        {
            var usersQuery = _context.Users.AsQueryable();

            // 🔍 Filtering: Search by FirstName, LastName, or Email
            if (!string.IsNullOrEmpty(query.Search))
            {
                var search = query.Search.ToLower();
                usersQuery = usersQuery.Where(u =>
                    u.FirstName.ToLower().Contains(search) ||
                    u.LastName.ToLower().Contains(search) ||
                    u.Email.ToLower().Contains(search));
            }

            // ✅ Filtering: By Role
            if (query.Role.HasValue)
            {
                usersQuery = usersQuery.Where(u => u.Role == query.Role.Value);
            }

            // ✅ Filtering: By IsActive status
            if (query.IsActive.HasValue)
            {
                usersQuery = usersQuery.Where(u => u.IsActive == query.IsActive.Value);
            }

            // total count before pagination
            var totalCount = await usersQuery.CountAsync();

            // 📄 Pagination
            if (query.Page > 0 && query.Limit > 0)
            {
                usersQuery = usersQuery
                    .OrderBy(u => u.UpdatedAt) // sort by created date
                    .Skip((query.Page - 1) * query.Limit)
                    .Take(query.Limit);
            }

            var users = await usersQuery
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();

            return (users, totalCount);
        }


        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
