using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN232_PE_FA25_NguyenKhanhTin.Data;
using PRN232_PE_FA25_NguyenKhanhTin.Models;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PostsController(ApplicationDbContext context) => _context = context;

    // GET: api/Posts?search=abc&sort=asc|desc
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts([FromQuery] string? search, [FromQuery] string? sort)
    {
        IQueryable<Post> q = _context.Posts.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
            q = q.Where(p => p.Name.Contains(search));

        q = (sort?.ToLower()) switch
        {
            "desc" => q.OrderByDescending(p => p.Name),
            _ => q.OrderBy(p => p.Name)
        };

        return await q.ToListAsync();
    }

    // GET: api/Posts/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        return post is null ? NotFound() : post;
    }

    // POST: api/Posts
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // chỉ nhận Name & Description bắt buộc; ImageUrl optional
        post.Id = 0;
        post.CreatedAt = DateTime.UtcNow;

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    // PUT: api/Posts/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] Post post)
    {
        if (id != post.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var dbPost = await _context.Posts.FindAsync(id);
        if (dbPost is null) return NotFound();

        dbPost.Name = post.Name.Trim();
        dbPost.Description = post.Description.Trim();
        dbPost.ImageUrl = string.IsNullOrWhiteSpace(post.ImageUrl) ? null : post.ImageUrl.Trim();

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Posts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post is null) return NotFound();

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
