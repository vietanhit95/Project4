//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonDangTin
    {
        public int MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public string MoTa { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
        public int MaBaiViet { get; set; }
        public Nullable<double> SoTien { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}