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
    public class BaiDangController : Controller
    {
        //
        // GET: /Admin/BaiDang/
        DoAn4Entities db = new DoAn4Entities();
        public ActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.BaiViets.Where(n=> n.TrangThai == "co").OrderBy(n =>n.TieuDe).ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]
        public ActionResult Delete(int Mabv)
        {
            BaiViet bv = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == Mabv);
            if(bv== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Deleted(int Mabv)
        {
            BaiViet bv = db.BaiViets.SingleOrDefault(n => n.MaBaiViet==Mabv);
            if(bv== null)
            {
                Response.StatusCode = 404;
                return null;
            }           
                db.BaiViets.Remove(bv);
                db.SaveChanges();
                return RedirectToAction("Index");         
        }
	}
}