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
    public class DuyetBaiController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        // GET: /Admin/DuyetBai/
        public ActionResult Index( int? page)
        {
            int pageSize = 6;
            int pageNumber = ( page ?? 1);
            return View(db.BaiViets.Where(n => n.TrangThai == null).OrderBy(n => n.TieuDe).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Edit(int MaBV , int? selectecdID = null)
        {
            BaiViet bv = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBV);
            if(bv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bv);
        }
        [HttpPost]
        public ActionResult Edit(BaiViet BV)
        {
            if(ModelState.IsValid)
            {
                //var tenanh = Path.GetFileName(photo.FileName);
                //var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), tenanh);
                //photo.SaveAs(path);
                //BV.Image = photo.FileName;
                db.Entry(BV).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
	}
}