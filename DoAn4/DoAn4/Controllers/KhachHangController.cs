using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;

namespace DoAn4.Controllers
{
    public class KhachHangController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();

        //
        // GET: /KhachHang/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh)
        {


            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangNhap", "KhachHang");
            }
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
            string tk = f["txtTaiKhoan"].ToString();
            string mk = f.Get("txtMatKhau").ToString();

            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TenDangNhap == tk && n.MatKhau == mk);
            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công ^^";
                Session["TenDangNhap"] = tk;
                Session["MatKhau"] = mk;
                //return RedirectToAction("DangBai", "QuanLyBaiViet");
                return View();

            }
            ViewBag.ThongBao = "Tài khoản hoặc mật khẩu sai @@";
            return View();
        }
        public ActionResult DangXuat()
        {
            Session["TenDangNhap"] = null;
            Session["MatKhau"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}