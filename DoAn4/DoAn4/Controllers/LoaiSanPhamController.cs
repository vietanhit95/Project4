using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;

namespace DoAn4.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();

        //
        // GET: /LoaiSanPham/
        public ActionResult LoaiSanPham()
        {

            return PartialView(db.NhomSanPhams.Take(6).ToList());
        }
        //bài viết theo chủ đề
        public ViewResult BaiVietTheoChuDe(int MaNhom=0)
        {
            NhomSanPham nhom=db.NhomSanPhams.SingleOrDefault(n=>n.MaNhomSanPham==MaNhom);
            if(nhom==null)
            {
                Response.StatusCode=404;
                return null;
            }

            List<BaiViet> baiviet = db.BaiViets.Where(n => n.MaNhomSanPham == MaNhom).OrderBy(n => n.GiaBan).ToList();
            if(baiviet.Count==0)
            {
                ViewBag.baiviet = "Không có bài biết nào ^^";// truyền dl từ controll -> view
            }
            return View(baiviet);
        }

        //view tất cả nhóm sp
        public ViewResult DanhMucNhom()
        {
            return View(db.NhomSanPhams.ToList());
        }

	}
}