using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn4.Models
{
    public class KhoBaiViet
    {
        DoAn4Entities db = new DoAn4Entities();
        public int maBV { get; set; }
        public string tenBV { get; set; }
        public string HinhAnh {get; set;}
        public float Gia { get; set; }

        public float ThanhTien
        {
            get { return 20000; }
        }
        public KhoBaiViet(int MaBV)
        {
            maBV = MaBV;
            BaiViet baiviet = db.BaiViets.Single(n => n.MaBaiViet == maBV);
            tenBV = baiviet.TieuDe;
            HinhAnh = baiviet.Image;
            Gia = float.Parse(baiviet.GiaBan.ToString());
        }
    }
}