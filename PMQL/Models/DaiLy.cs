using System.ComponentModel.DataAnnotations;

namespace PMQL.Models
{
    public class DaiLy
    {
        [Key]  //  Đánh dấu MaDaiLy là khóa chính
        public string MaDaiLy { get; set; }

        public string TenDaiLy { get; set; }
        public string DiaChi { get; set; }
        public string NguoiDaiDien { get; set; }
        public string DienThoai { get; set; }

        public string MaHTPP { get; set; } // Liên kết với hệ thống phân phối
    }
}
