using System.ComponentModel.DataAnnotations;

namespace PRN232_PE_FA25_NguyenKhanhTin.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Url]
        public string? ImageUrl { get; set; } // optional

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
