using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Net.Mail;

namespace DoAn4.Controllers
{
    public class QuanLyBaiVietController : Controller
    {
        //
        // GET: /QuanLyBaiViet/
        DoAn4Entities db = new DoAn4Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Them()
        {

            ViewBag.MaVungMien = new SelectList(db.VungMiens.ToList().OrderBy(n => n.TenVungMien), "MaVungMien", "TenVungMien");
            ViewBag.MaChuyenMuc = new SelectList(db.ChuyenMucs.ToList().OrderBy(n => n.TenChuyenMuc), "MaChuyenMuc", "TenChuyenMuc");
            ViewBag.MaNhomSanPham = new SelectList(db.NhomSanPhams.ToList().OrderBy(n => n.TenNhomSanPham), "MaNhomSanPham", "TenNhomSanPham");
            return View();

        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Them(BaiViet baiviet, HttpPostedFileBase fileupload)
        {
            ViewBag.MaVungMien = new SelectList(db.VungMiens.ToList().OrderBy(n => n.TenVungMien), "MaVungMien", "TenVungMien");
            ViewBag.MaChuyenMuc = new SelectList(db.ChuyenMucs.ToList().OrderBy(n => n.TenChuyenMuc), "MaChuyenMuc", "TenChuyenMuc");
            ViewBag.MaNhomSanPham = new SelectList(db.NhomSanPhams.ToList().OrderBy(n => n.TenNhomSanPham), "MaNhomSanPham", "TenNhomSanPham");

            //add data vào csdl
            if (fileupload == null)
            {
                ViewBag.ThongBao = "Hãy chọn 1 ảnh ^^";
                return View();
            }
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                fileupload.SaveAs(path);
                baiviet.Image = fileupload.FileName;
                db.BaiViets.Add(baiviet);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng thành công ^^";


                StringBuilder Body = new StringBuilder();
                Body.Append("<p>Cảm ơn quý khách đã đăng tải sản phẩm tại RaoVatAA.com!</p>");
                Body.Append("<table>");
                Body.Append("<tr><td>Người gửi:</td><td>Nguyễn Hoàng Anh</td></tr>");
                Body.Append("<tr><td>Số điện thoại:</td><td>0972471294</td></tr>");
                Body.Append("<tr><td>Địa chỉ:</td><td>Hưng Yên</td></tr>");

                Body.Append("</table>");

                MailMessage mail = new MailMessage();
                mail.To.Add(baiviet.EmailLienHe);
                mail.From = new MailAddress("hoanganhcnpm@gmail.com");
                mail.Subject = "[RaoVatAA.com]";
                mail.Body = Body.ToString();
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("hoanganhcnpm@gmail.com", "hoanganh123");
                smtp.EnableSsl = true;
                smtp.Send(mail);





            }
            return View();
        }


        //xem chi tiết
        public ViewResult ChiTietSP(int MaBaiViet = 0)
        {
            BaiViet baiviet = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == MaBaiViet);
            if (baiviet == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(baiviet);
        }
        // đăng bài trả phí
        #region đăng bài trả phí
        [HttpGet]
        public ActionResult DangBai()
        {


            ViewBag.MaVungMien = new SelectList(db.VungMiens.ToList().OrderBy(n => n.TenVungMien), "MaVungMien", "TenVungMien");
            ViewBag.MaChuyenMuc = new SelectList(db.ChuyenMucs.ToList().OrderBy(n => n.TenChuyenMuc), "MaChuyenMuc", "TenChuyenMuc");
            ViewBag.MaNhomSanPham = new SelectList(db.NhomSanPhams.ToList().OrderBy(n => n.TenNhomSanPham), "MaNhomSanPham", "TenNhomSanPham");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DangBai(BaiViet bd, HttpPostedFileBase fileupload)
        {
            ViewBag.MaVungMien = new SelectList(db.VungMiens.ToList().OrderBy(n => n.TenVungMien), "MaVungMien", "TenVungMien");
            ViewBag.MaChuyenMuc = new SelectList(db.ChuyenMucs.ToList().OrderBy(n => n.TenChuyenMuc), "MaChuyenMuc", "TenChuyenMuc");
            ViewBag.MaNhomSanPham = new SelectList(db.NhomSanPhams.ToList().OrderBy(n => n.TenNhomSanPham), "MaNhomSanPham", "TenNhomSanPham");
            //kiểm tra đăng nhập
            if (Session["TenDangNhap"] == null || Session["TenDangNhap"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }

            //add data vào csdl
            if (fileupload == null)
            {
                ViewBag.ThongBao = "Hãy chọn 1 ảnh ^^";
                return View();
            }
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                //if (System.IO.File.Exists(path))
                //{
                //ViewBag.ThongBao("Ảnh tồn tại ^^");
                //}
                //else
                //{
                fileupload.SaveAs(path);
                //}
                bd.Image = fileupload.FileName;
                string ma = Session["TenDangNhap"].ToString();
                KhachHang kh = db.KhachHangs.SingleOrDefault(k => k.TenDangNhap == ma);
                bd.MaKhachHang = kh.MaKhachHang;
                db.BaiViets.Add(bd);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng thành công ^^";



                StringBuilder Body = new StringBuilder();
                Body.Append("<p>Cảm ơn quý khách đã đăng tải sản phẩm tại RaoVatAA.com!</p>");
                Body.Append("<table>");
                Body.Append("<tr><td>Người gửi:</td><td>Nguyễn Hoàng Anh</td></tr>");
                Body.Append("<tr><td>Số điện thoại:</td><td>0972471294</td></tr>");
                Body.Append("<tr><td>Địa chỉ:</td><td>Hưng Yên</td></tr>");

                Body.Append("</table>");

                MailMessage mail = new MailMessage();
                mail.To.Add(bd.EmailLienHe);
                mail.From = new MailAddress("hoanganhcnpm@gmail.com");
                mail.Subject = "[RaoVatAA.com]";
                mail.Body = Body.ToString();
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("hoanganhcnpm@gmail.com", "hoanganh123");
                smtp.EnableSsl = true;
                smtp.Send(mail);



            }

            return View();

        }

        #endregion



    }
}