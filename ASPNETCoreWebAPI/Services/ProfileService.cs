using ASPNETCoreWebAPI.Db;
using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Services
{
    public class ProfileService : IProfileService
    {

        private readonly ASPNETCoreWebAPIDbContext _context;
        public ProfileService(ASPNETCoreWebAPIDbContext context)
        {
            _context = context;
        }
        public async Task<ProfileResponseDto> CreateAsync(CreateProfileDto dto)
        {
            var user = await _context.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == dto.UserId);

            if (user == null)
                throw new Exception("User not found.");

            if (user.Profile != null)
                throw new Exception("User already has a profile.");

            var profile = new Profile
            {
                Dob = dto.Dob,
                Gender = dto.Gender,
                Avatar_URL = dto.Avatar_URL,
                UserId = dto.UserId
            };

            _context.Profile.Add(profile);
            await _context.SaveChangesAsync();

            return new ProfileResponseDto
            {
                Id = profile.Id,
                Dob = profile.Dob,
                Gender = profile.Gender,
                Avatar_URL = profile.Avatar_URL,
                UserId = profile.UserId
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null) return false;

            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProfileResponseDto>> GetAllAsync()
        {
            return await _context.Profile
                .Select(p => new ProfileResponseDto
                {
                    Id = p.Id,
                    Dob = p.Dob,
                    Gender = p.Gender,
                    Avatar_URL = p.Avatar_URL,
                    UserId = p.UserId
                })
                .ToListAsync();
        }

        public async Task<ProfileResponseDto?> GetByIdAsync(int id)
        {
            var profile = await _context.Profile.FindAsync(id);

            if (profile == null) return null;

            return new ProfileResponseDto
            {
                Id = profile.Id,
                Dob = profile.Dob,
                Gender = profile.Gender,
                Avatar_URL = profile.Avatar_URL,
                UserId = profile.UserId
            };
        }

        public async Task<ProfileResponseDto?> UpdateAsync(int id, UpdateProfileDto dto)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null) return null;

            profile.Dob = dto.Dob;
            profile.Gender = dto.Gender;
            profile.Avatar_URL = dto.Avatar_URL;

            await _context.SaveChangesAsync();

            return new ProfileResponseDto
            {
                Id = profile.Id,
                Dob = profile.Dob,
                Gender = profile.Gender,
                Avatar_URL = profile.Avatar_URL,
                UserId = profile.UserId
            };
        }
    }
}
