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
    
    public partial class ChuyenMuc
    {
        public ChuyenMuc()
        {
            this.BaiViets = new HashSet<BaiViet>();
        }
    
        public int MaChuyenMuc { get; set; }
        public string TenChuyenMuc { get; set; }
    
        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}
