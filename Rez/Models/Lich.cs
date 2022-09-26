using System.ComponentModel.DataAnnotations;

namespace Rez.Models
{
    /// <summary>
    /// Lịch
    /// </summary>
    public class Lich
    {
        /// <summary>
        /// Guid
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Thời gian lịch bắt đầu
        /// </summary>
        public DateTime ThoiGianBatDau { get; set; }
        /// <summary>
        /// Thời gian lịch kết thúc
        /// </summary>
        public DateTime ThoiGianKetThuc { get; set; }

        /// <summary>
        /// Enum tình trạng
        /// </summary>
        public enum TinhTrang
        {
            /// <summary>
            /// Chưa bắt đầu
            /// </summary>
            ChuaBatDau,
            /// <summary>
            /// Đang tiếp diễn
            /// </summary>
            DangTiepDien,
            /// <summary>
            /// Đã xong
            /// </summary>
            DaXong,
            /// <summary>
            /// Đã huỷ
            /// </summary>
            DaHuy
        }

        /// <summary>
        /// Tình trạng
        /// </summary>
        public TinhTrang TinhTrangLich { get; set; } = TinhTrang.ChuaBatDau;

        public virtual Lop? Lop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Timestamp]
        public byte[]? Timestamp { get; set; }
    }
}
