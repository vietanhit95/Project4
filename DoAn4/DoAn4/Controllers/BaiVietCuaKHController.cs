using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace DoAn4.Controllers
{
    public class BaiVietCuaKHController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        //
        // GET: /BaiVietCuaKH/
        public ActionResult BaiVietCuaKH(int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);

            string ma = Session["TenDangNhap"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDangNhap == ma);
            return View(db.BaiViets.Where(n => n.MaKhachHang == kh.MaKhachHang).OrderBy(n => n.GiaBan).ToPagedList(pageNum, pageSize));
        }
        //bài đăng đã duyệt
        public ActionResult BaiVietDaDuyet(int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);
         
            string ma = Session["TenDangNhap"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDangNhap == ma);
            return View(db.BaiViets.Where(n => n.MaKhachHang == kh.MaKhachHang).Where(n=>n.TrangThai=="co").OrderBy(n => n.GiaBan).ToPagedList(pageNum, pageSize));
        }
        //bài đăng chờ duyệt
        public ActionResult BaiVietChoDuyet(int? page)
        {
            int pageSize = 6;
            int pageNum = (page ?? 1);

            string ma = Session["TenDangNhap"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDangNhap == ma);
            return View(db.BaiViets.Where(n => n.MaKhachHang == kh.MaKhachHang).Where(n => n.TrangThai == null ).OrderBy(n => n.GiaBan).ToPagedList(pageNum, pageSize));
        }

        //sửa
        [HttpGet]
        public ActionResult Sua(int MaBV)
        {
            BaiViet baiviet = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if (baiviet == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.MaVungMien = new SelectList(db.VungMiens.ToList().OrderBy(n => n.TenVungMien), "MaVungMien", "TenVungMien");
            ViewBag.MaChuyenMuc = new SelectList(db.ChuyenMucs.ToList().OrderBy(n => n.TenChuyenMuc), "MaChuyenMuc", "TenChuyenMuc");
            ViewBag.MaNhomSanPham = new SelectList(db.NhomSanPhams.ToList().OrderBy(n => n.TenNhomSanPham), "MaNhomSanPham", "TenNhomSanPham");


            return View(baiviet);
        }


        [HttpPost]
        
        public ActionResult Sua(BaiViet baiviet)
        {
            ViewBag.MaVungMien = new SelectList(db.VungMiens.ToList().OrderBy(n => n.TenVungMien), "MaVungMien", "TenVungMien");
            ViewBag.MaChuyenMuc = new SelectList(db.ChuyenMucs.ToList().OrderBy(n => n.TenChuyenMuc), "MaChuyenMuc", "TenChuyenMuc");
            ViewBag.MaNhomSanPham = new SelectList(db.NhomSanPhams.ToList().OrderBy(n => n.TenNhomSanPham), "MaNhomSanPham", "TenNhomSanPham");

            //add data vào csdl
            //if (fileupload == null)
            //{
            //    ViewBag.ThongBao = "Hãy chọn 1 ảnh ^^";
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                //var fileName = Path.GetFileName(fileupload.FileName);
                //var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);

                //fileupload.SaveAs(path);

                //baiviet.Image = fileupload.FileName;
               
                db.Entry(baiviet).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            
            return RedirectToAction("BaiVietCuaKH");
        }
       
        //Xóa
        public ActionResult Xoa(int MaBV)
        {
            BaiViet baiviet = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if (baiviet == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(baiviet);
        }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XoaBai(int MaBV)
        {
            BaiViet baiviet = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if(baiviet==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.BaiViets.Remove(baiviet);
            db.SaveChanges();
            return RedirectToAction("BaiVietCuaKH");

        }

    }
}