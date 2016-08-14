using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAn4.Models
{
    [MetadataTypeAttribute(typeof(BaiVietMetadata))]
    public partial class BaiViet
    {
        internal sealed class BaiVietMetadata
        {
            [Required(ErrorMessage = "Không được trống :(")]
            [Display(Name = "Mã bài viết")]
            public int MaBaiViet { get; set; }
            
            [Display(Name = "Chuyên mục")]
            public int MaChuyenMuc { get; set; }
           
            [Display(Name = "Nhóm sản phẩm")]
            public int MaNhomSanPham { get; set; }
          
            [Display(Name = "Mã khách hàng")]
            public int MaKhachHang { get; set; }
          
            [Display(Name = "Vùng miền")]
            public int MaVungMien { get; set; }
            [Required(ErrorMessage = "Không được trống")]
            [Display(Name = "Tiêu đề")]
            public string TieuDe { get; set; }
            [Required(ErrorMessage = "Không được trống ")]
            [Display(Name = "Nội dung")]
            public string NoiDung { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "dd/MM/yyyy", ApplyFormatInEditMode = true)]//định dạng ngày
            [Display(Name = "Ngày đăng")]
            public Nullable<System.DateTime> NgayDang { get; set; }
           
            
            [Display(Name = "Người liên hệ")]
            [Required(ErrorMessage="Tên người liên hệ không được để trống")]
            public string TenNguoiLienHe { get; set; }
            [Required(ErrorMessage = "Không được trống :(")]
            [Display(Name = "Địa chỉ")]
            public string DiaChiLienHe { get; set; }
            [Required(ErrorMessage = "Không được trống")]
            [Display(Name = "Số điện thoại")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "SĐT không hợp lệ")]
            public string SDTLienHe { get; set; }
            [Required(ErrorMessage = "Không được trống")]
            [Display(Name = "Email")]
            [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "{0} Email không hợp lệ")]
            public string EmailLienHe { get; set; }
          
            [Display(Name = "Ảnh")]
            public string Image { get; set; }
            [Display(Name = "Giá")]
            [Required(ErrorMessage = "Không được trống")]
            public Nullable<double> GiaBan { get; set; }
          
        }
    }
}