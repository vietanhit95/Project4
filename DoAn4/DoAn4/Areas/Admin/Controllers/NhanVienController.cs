using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAn4.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace DoAn4.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        Admin_HomeController ad = new Admin_HomeController();
        // GET: /Admin/NhanVien/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.NhanViens.OrderBy(n => n.MaNhanVien).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NhanVien nv)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();

                //SetAlert("Đăng Ký Thành Công !","success");
            }

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(NhanVien nv, HttpPostedFileBase photo)
        {

            if (ModelState.IsValid && photo != null)
            {
                var tenanh = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), tenanh);
                photo.SaveAs(path);
                nv.Image = photo.FileName;
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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
        public ActionResult Edit(NhanVien nv, HttpPostedFileBase photo)
        {
            //string directory = @"D:\Temp\";

            //if (photo != null && photo.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(photo.FileName);
            //    photo.SaveAs(Path.Combine(directory, fileName));
            //}
            //else
            if (ModelState.IsValid && photo != null)
            {
                var tenanh = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), tenanh);
                photo.SaveAs(path);
                nv.Image = photo.FileName;
                db.Entry(nv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        //public void SetAlert(string message, string type)
        //{
        //    TempData["AlertMessage"] = message;
        //    if (type == "success")
        //    {
        //        TempData["AlertType"] = "alert-success";
        //    }
        //    else if (type == "warning")
        //    {
        //        TempData["AlertType"] = "alert-warning";
        //    }
        //    else if (type == "error")
        //    {
        //        TempData["AlertType"] = "alert-danger";
        //    }

        //}
    }
}