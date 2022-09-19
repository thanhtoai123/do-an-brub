using System.ComponentModel.DataAnnotations;

namespace Rez.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Lop
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Ten { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}
