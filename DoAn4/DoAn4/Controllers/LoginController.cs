using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAn4.Models;

namespace DoAn4.Controllers
{
    public class LoginController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string ten = f.Get("username").ToString();
            string pass = f.Get("pass").ToString();
            NhanVien nv = db.NhanViens.SingleOrDefault(n => n.TenDangNhap == ten && n.MatKhau == pass);
            if (nv != null)
            {
                Session["TenDangNhap"] = nv;
                return RedirectToAction("TrangChu", "Home");
            }
            return View();
        }
	}
}