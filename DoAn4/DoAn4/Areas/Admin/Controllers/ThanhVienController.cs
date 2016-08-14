using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAn4.Models;
using PagedList;
using PagedList.Mvc;

namespace DoAn4.Areas.Admin.Controllers
{
    public class ThanhVienController : Controller
    {

        //
        // GET: /Admin/ThanhVien/
        DoAn4Entities db = new DoAn4Entities();

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.KhachHangs.OrderBy(n=>n.MaKhachHang).ToPagedList(pageNumber,pageSize));
        }

        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }
        [HttpGet]
        public ActionResult Sua(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKhachHang == MaKH);
            if(kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost]
        public ActionResult Sua(KhachHang kh)
        {
            if(ModelState.IsValid)
            {
                db.Entry(kh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }
        [HttpGet]
        public ActionResult Xoa(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n=> n.MaKhachHang== MaKH);
            if(kh ==  null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaKH)
        {
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKhachHang == MaKH);
            if(kh== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}