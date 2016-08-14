using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAn4.Models;
using PagedList.Mvc;
using PagedList;
using System.IO;

namespace DoAn4.Areas.Admin.Controllers
{
    public class LuuTruBaiDangController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        //
        // GET: /Admin/LuuTruBaiDang/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(db.BaiViets.Where(n => n.TrangThai == "Ko").OrderBy(n => n.TieuDe).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(int MaBV)
        {
            BaiViet bv = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if (bv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bv);
        }
        [HttpPost]
        public ActionResult Edit(BaiViet BV)
        {
            if (ModelState.IsValid )
            {
                db.Entry(BV).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(BV);
        }

    }
}