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
    public class VungMienController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        // GET: /Admin/VungMien/
        public ActionResult Index(int? page)
        {
            int pageSize = 13;
            int pageNumber = (page ?? 1);
            return View(db.VungMiens.OrderBy(n=>n.MaVungMien).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(VungMien VM)
        {
            if (ModelState.IsValid)
            {
                db.VungMiens.Add(VM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(VM);
        }
        [HttpGet]
        public ActionResult Edit(int MaVM)
        {
            VungMien VM = db.VungMiens.SingleOrDefault(n => n.MaVungMien == MaVM);
            if (VM == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(VM);
        }
        [HttpPost]
        public ActionResult Edit(VungMien VM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VM).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(VM);
        }
        [HttpGet]
        public ActionResult Delete(int MaVM)
        {
            VungMien vm = db.VungMiens.SingleOrDefault(n => n.MaVungMien == MaVM);
            if (vm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(vm);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult Deleted(int MaVM)
        {
            VungMien VM = db.VungMiens.SingleOrDefault(n => n.MaVungMien == MaVM);
            if(ModelState.IsValid)
            {
                db.VungMiens.Remove(VM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(VM);
        }
    }
}