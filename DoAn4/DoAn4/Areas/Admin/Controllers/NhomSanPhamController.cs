using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAn4.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;
namespace DoAn4.Areas.Admin.Controllers
{
    public class NhomSanPhamController : Controller
    {
        DoAn4Entities rv = new DoAn4Entities();
        // GET: /Admin/NhomSanPham/
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber =(page ?? 1);
            return View(rv.NhomSanPhams.OrderBy(n=>n.MaNhomSanPham).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhomSanPham NSP,HttpPostedFileBase photo)
        {
            if (ModelState.IsValid && photo != null)
            {
                var tenanh = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), tenanh);
                photo.SaveAs(path);
                NSP.Image = photo.FileName;
                rv.NhomSanPhams.Add(NSP);
                rv.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int MaNSP)
        {
            NhomSanPham NSP = rv.NhomSanPhams.SingleOrDefault(n => n.MaNhomSanPham == MaNSP);
            if (NSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NSP);
        }
        [HttpPost]
        public ActionResult Edit(NhomSanPham NSP, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid && photo != null)
            {
                var tenanh = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/Image"), tenanh);
                photo.SaveAs(path);
                NSP.Image = photo.FileName;
                rv.Entry(NSP).State = System.Data.Entity.EntityState.Modified;
                rv.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(NSP);

        }
        [HttpGet]
        public ActionResult Delete(int MaNSP)
        {
            NhomSanPham NSP = rv.NhomSanPhams.SingleOrDefault(n => n.MaNhomSanPham == MaNSP);
            if (NSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NSP);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleted(int MaNSP)
        {
            NhomSanPham NSP = rv.NhomSanPhams.SingleOrDefault(n => n.MaNhomSanPham == MaNSP);
            if (ModelState.IsValid)
            {
                rv.NhomSanPhams.Remove(NSP);
                rv.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(NSP);
        }
    }
}