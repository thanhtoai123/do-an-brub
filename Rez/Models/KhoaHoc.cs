using System.ComponentModel.DataAnnotations;

namespace Rez.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class KhoaHoc
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Ten { get; set; } = null!;
        
        /// <summary>
        /// 
        /// </summary>
        public string? MieuTa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Models.Mon>? Mon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}
