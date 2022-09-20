using System.ComponentModel.DataAnnotations;

namespace Rez.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Lich
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 
        /// </summary>
        public DateTime ThoiGianBatDau { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ThoiGianKetThuc { get; set; }
        public virtual Lop? Lop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}
