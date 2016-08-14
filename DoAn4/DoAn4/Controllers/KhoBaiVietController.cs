using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;

namespace DoAn4.Controllers
{
    public class KhoBaiVietController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        //
        // GET: /KhoBaiViet/
        //lay kho hang da ton ta
        #region Kho hàng
        public List<KhoBaiViet> LayKhoBV()
        {
            List<KhoBaiViet> lstKhoBV = Session["KhoBaiViet"] as List<KhoBaiViet>;
            if (lstKhoBV == null)
            {
                lstKhoBV = new List<KhoBaiViet>();
                Session["KhoBaiViet"] = lstKhoBV;

            }
            return lstKhoBV;
        }
        //them kho bai viet
        public ActionResult ThemKhoBV(int maBV, string url)
        {
            BaiViet baiviet = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == maBV);
            if(baiviet==null)
            {
                Response.StatusCode = 404;
                return null; 
            }
            List<KhoBaiViet> lstKhoBV = LayKhoBV();
            //kiem tra bài viết tồn tại trong sesion kho chưa
            KhoBaiViet kho = lstKhoBV.Find(n => n.maBV == maBV);
            if(kho==null)
            {
                kho = new KhoBaiViet(maBV);
                //add bài viết mới vào kho
                lstKhoBV.Add(kho);
                
                return Redirect(url);

            }
            else
            {
                return Redirect(url);
            }
        }
        //update kho bài viết
        public ActionResult Update(int maBV)
        {
            BaiViet bv = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == maBV);
            if(bv==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy kho hàng từ session
            List<KhoBaiViet> lstKhoBV = LayKhoBV();
            KhoBaiViet baiviet = lstKhoBV.SingleOrDefault(n => n.maBV == maBV);
            if(baiviet!=null)
            {


                
            }
            return View("KhoBaiViet");
        }
    //xóa kho bài viết
        public ActionResult Xoa(int mabv)
        {
            BaiViet bv = db.BaiViets.SingleOrDefault(n => n.MaBaiViet == mabv);
            if (bv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<KhoBaiViet> lstKhoBV = LayKhoBV();
            KhoBaiViet baiviet = lstKhoBV.SingleOrDefault(n => n.maBV == mabv);
            if (baiviet != null)
            {
                lstKhoBV.RemoveAll(n => n.maBV == baiviet.maBV);
               

            }
            if(lstKhoBV.Count==0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("KhoBaiViet");
        }
        //xây dưng trang kho bài viết
        public ActionResult KhoBaiViet()
        {
            if(Session["KhoBaiViet"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<KhoBaiViet> lstKhoBV=LayKhoBV();
            return View(lstKhoBV);
        }
        //Tính tổng tiền
        private float TongTien()
        {
            float tongtien = 0;
            List<KhoBaiViet> kho = Session["KhoBaiViet"] as List<KhoBaiViet>;
            if(kho!=null)
            {
                tongtien = kho.Sum(n => n.ThanhTien);

            }
            return tongtien;
        }
        //tạo partial kho hàng
        public ActionResult KhoHangPartial()
        {
            

            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        #endregion


       
    }
       

  
}