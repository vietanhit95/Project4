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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DoAn4Entities db = new DoAn4Entities();

        public ActionResult Index(int? page)
        {     
            int pageSize = 6;
            int pageNum = (page ?? 1);
       
            return View(db.BaiViets.Where(n => n.TrangThai == "co").Where(n=>n.MaKhachHang !=null).OrderBy(n => n.GiaBan).ToPagedList(pageNum, pageSize));
            //return View(db.BaiViets.OrderBy(n => n.GiaBan).ToPagedList(pageNum, pageSize));
        }
        public PartialViewResult VungMienPartial()
        {
            var lstVungMien = db.VungMiens.Take(6).ToList();
            return PartialView(lstVungMien);
        }
        //bài viết theo vùng miền
        public ViewResult BaiVietTheoVungMien(int MaVM=0)
        {
            VungMien VM = db.VungMiens.SingleOrDefault(n => n.MaVungMien == MaVM);
            if(VM==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<BaiViet> baiviet = db.BaiViets.Where(n => n.MaVungMien == MaVM).OrderBy(n => n.GiaBan).ToList();
            if(baiviet.Count==0)
            {
                ViewBag.baiviet = "Không có bài viết nào ^^";
            }
            return View(baiviet);
        }
        //view tất cả vùng miền
        public ViewResult DanhMucVungMien()
        {
            return View(db.VungMiens.ToList());
        }




        //admin
        public ActionResult TrangChu(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.NhanViens.Where(n => n.QuyenHan == "Admin").OrderBy(n => n.HoTen).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanvien);
                db.SaveChanges();
            }
            return RedirectToAction("TrangChu");
        }
        [HttpGet]
        public ActionResult Edit(int MaNV)
        {
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == MaNV);
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nv);
        }
        [HttpPost]
        public ActionResult Edit(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TrangChu");
            }
            return View(nv);
        }
        [HttpGet]
        public ActionResult Delete(int MaNV)
        {
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == MaNV);
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nv);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleted(int MaNV)
        {
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == MaNV);
            if (nv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhanViens.Remove(nv);
            db.SaveChanges();
            return RedirectToAction("TrangChu");
        }

	}
}