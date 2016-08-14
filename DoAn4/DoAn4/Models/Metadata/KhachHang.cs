using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAn4.Models
{
     [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
          internal sealed class KhachHangMetadata
          {
              
              [Display(Name = "Mã khách hàng")]
              public int MaKhachHang { get; set; }
              [Display(Name = "Họ tên")]
              [Required(ErrorMessage = "Không được trống :(")]
              public string HoTen { get; set; }
              [Display(Name = "Tên đăng nhập")]
              [Required(ErrorMessage = "Không được trống :(")]
              public string TenDangNhap { get; set; }
              [Display(Name = "Mật khẩu")]
              [Required(ErrorMessage = "Không được trống :(")]
              public string MatKhau { get; set; }
              [Display(Name = "Địa chỉ")]
              public string DiaChi { get; set; }
              [Display(Name = "Số điện thoại")]
              [Required(ErrorMessage = "Không được trống :(")]
              [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "SĐT không hợp lệ")]
              public string SDT { get; set; }
              [Display(Name = "Email")]
              [Required(ErrorMessage = "Không được trống :(")]
              [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"+"[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "{0} Email không hợp lệ")]
              public string Email { get; set; }
              [Display(Name = "Ngày đăng kí")]
              [DataType(DataType.Date)]
              [DisplayFormat(DataFormatString = "0:dd/MM/yyyy", ApplyFormatInEditMode = true)]//định dạng ngày
              public Nullable<System.DateTime> NgayDangKi { get; set; }
              [Display(Name = "Nhập số seri thẻ cào điện thoại( mệnh giá 20k)")]
              [Required(ErrorMessage = "Không được trống :(")]
              public Nullable<double> SoTienDaNap { get; set; }
              [Display(Name = "Ghi chú")]
              public string GhiChu { get; set; }
          }
    }
}