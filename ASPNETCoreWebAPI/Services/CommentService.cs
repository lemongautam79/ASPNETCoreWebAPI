using ASPNETCoreWebAPI.Db;
using ASPNETCoreWebAPI.Dtos;
using ASPNETCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreWebAPI.Services
{
    public class CommentService : ICommentService
    {

        //DI
        private readonly ASPNETCoreWebAPIDbContext _context;

        public CommentService(ASPNETCoreWebAPIDbContext context)
        {
            _context = context;
        }

        public async Task<CommentResponseDto> CreateAsync(CommentDto request)
        {
            // Check if post exists
            var post = await _context.Posts.FindAsync(request.PostId);
            if (post == null)
                throw new Exception("Post not found");

            var comment = new Comment
            {
                Description = request.Description,
                PostId = request.PostId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new CommentResponseDto
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return false;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(IEnumerable<CommentResponseDto> Comments, int TotalCount)> GetAllAsync(CommentQueryDto query)
        {
            var commentsQuery = _context.Comments.AsQueryable();

            if (query.PostId.HasValue)
            {
                commentsQuery = commentsQuery.Where(c => c.PostId == query.PostId.Value);
            }

            var totalCount = await commentsQuery
                .Include(c=>c.PostId)
                .CountAsync();

            commentsQuery = commentsQuery.OrderByDescending(c => c.UpdatedAt);

            var comments = await commentsQuery
                .Select(c => new CommentResponseDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt,
                })
                .ToListAsync();

            return (comments, totalCount);
        }

        public async Task<CommentResponseDto?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;

            return new CommentResponseDto
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };
        }

        public async Task<IEnumerable<CommentResponseDto>> GetCommentsByPostIdAsync(int PostId)
        {
            return await _context.Comments
                .Where(c => c.PostId == PostId)
                .OrderByDescending(c => c.UpdatedAt)
                .Select(c => new CommentResponseDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<CommentResponseDto> UpdateAsync(int id, CommentDto request)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;

            var post = await _context.Posts.FindAsync(request.PostId);
            if (post == null)
                throw new Exception("Post not found");

            comment.Description = request.Description;
            comment.PostId = request.PostId;
            post.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return new CommentResponseDto
            {
                Id = comment.Id,
                Description = comment.Description,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }
    }
}
