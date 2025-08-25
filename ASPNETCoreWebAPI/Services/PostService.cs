using ASPNETCoreWebAPI.Db;
using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Services
{
    public class PostService : IPostService
    {

        //DI
        private readonly ASPNETCoreWebAPIDbContext _context;

        public PostService(ASPNETCoreWebAPIDbContext context)
        {
            _context = context;
        }

        public async Task<PostResponseDto> CreateAsync(PostDto request)
        {
            // Check if user exists
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found");

            var post = new Post
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new PostResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(IEnumerable<PostResponseDto> Posts, int TotalCount)> GetAllAsync(PostQueryDto query)
        {
            var postsQuery = _context.Posts.AsQueryable();

            // 🔍 Search by Title or Description
            if (!string.IsNullOrEmpty(query.Search))
            {
                var search = query.Search.ToLower();
                postsQuery = postsQuery.Where(p =>
                    p.Title.ToLower().Contains(search) ||
                    p.Description.ToLower().Contains(search));
            }

            // ✅ Filter by UserId
            if (query.UserId.HasValue)
            {
                postsQuery = postsQuery.Where(p => p.UserId == query.UserId.Value);
            }

            // ✅ Filter by CreatedAt date range
            if (query.FromDate.HasValue)
            {
                postsQuery = postsQuery.Where(p => p.CreatedAt >= query.FromDate.Value);
            }
            if (query.ToDate.HasValue)
            {
                postsQuery = postsQuery.Where(p => p.CreatedAt <= query.ToDate.Value);
            }

            // total count before pagination
            var totalCount = await postsQuery.CountAsync();

            // 📄 Pagination and sorting by latest updated
            postsQuery = postsQuery
                .OrderByDescending(p => p.UpdatedAt)
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit);

            var posts = await postsQuery
                .Select(p => new PostResponseDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Comments = p.Comments.Select(c => new CommentResponseDto
                    {
                        Id = c.Id,
                        Description = c.Description,
                        CreatedAt = c.CreatedAt,
                    }).ToList()
                })
                .ToListAsync();

            return (posts, totalCount);
        }

        public async Task<PostResponseDto?> GetByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return null;

            return new PostResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }

        public async Task<IEnumerable<PostResponseDto?>> GetPostsByUserIdAsync(Guid userId)
        {
            return await _context.Posts
         .Where(p => p.UserId == userId)
         .OrderByDescending(p => p.UpdatedAt)
         .Select(p => new PostResponseDto
         {
             Id = p.Id,
             Title = p.Title,
             Description = p.Description,
             CreatedAt = p.CreatedAt,
             UpdatedAt = p.UpdatedAt
         })
         .ToListAsync();
        }

        public async Task<PostResponseDto?> UpdateAsync(int id, PostDto request)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return null;

            // Optionally validate user exists
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                throw new Exception("User not found");

            post.Title = request.Title;
            post.Description = request.Description;
            post.UserId = request.UserId;
            post.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new PostResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }
    }
}
