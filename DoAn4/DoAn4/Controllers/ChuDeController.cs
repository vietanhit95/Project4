using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;
using PagedList;
using PagedList.Mvc;

namespace DoAn4.Controllers
{
    public class ChuDeController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        //
        // GET: /ChuDe/
        public PartialViewResult ChuDePartyal()
        {

            return PartialView(db.NhomSanPhams.Take(6).OrderBy(n => n.TenNhomSanPham).ToList());
        }
        //bài viết theo chủ đề
        public ViewResult BaiVietTheoNhom(int MaCD = 0)
        {
            NhomSanPham nhom = db.NhomSanPhams.SingleOrDefault(n => n.MaNhomSanPham == MaCD);
            if (nhom == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<BaiViet> baiviet = db.BaiViets.Where(n => n.MaNhomSanPham == MaCD).OrderBy(n => n.GiaBan).ToList();
            if (baiviet.Count == 0)
            {
                ViewBag.baiviet = "Không có bài biết nào ^^";// truyền dl từ controll -> view
            }
            return View(baiviet);
            
        }
        public ViewResult DanhMucNhom()
        {
            return View(db.NhomSanPhams.ToList());
        }

        

	}
}