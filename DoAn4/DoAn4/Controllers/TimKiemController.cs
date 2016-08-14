using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn4.Models;
using PagedList.Mvc;
using PagedList;
namespace DoAn4.Controllers
{
    public class TimKiemController : Controller
    {
        DoAn4Entities db = new DoAn4Entities();
        //
        // GET: /TimKiem/
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int? page)
        {
            string tukhoa = f["txtTimKiem"].ToString();
            List<BaiViet> kqtl = db.BaiViets.Where(n => n.TieuDe.Contains(tukhoa)).ToList();
            //phân trang

            int pageNum = (page ?? 1);
            int pageSize = 9;
            if (kqtl.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy bài viết liên quan ^^";
               
            }
            ViewBag.ThongBao="Đã tìm thấy: " + kqtl.Count + " kết quả";
            return View(kqtl.OrderBy(n => n.TieuDe).ToPagedList(pageNum, pageSize));
            
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            string TuKhoa = f["seachString"].ToString();
            List<NhanVien> KQ = db.NhanViens.Where(n => n.HoTen.Contains(TuKhoa)).ToList();
            return View(KQ.OrderBy(n => n.HoTen).ToList());
        }


        }
	}
