using Demo_DeSoMot.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace Demo_DeSoMot.Controllers
{
    public class SinhVienController : Controller
    {
        //gọi class đại diện sql sang
        SV_LOPHOCContext _db;
        //tiêm db vào controle
        public SinhVienController(SV_LOPHOCContext db)
        {
            _db = db;
        }

        //Xem list sv
        //tên hàm = tên action
        public IActionResult Index()
        {
            //var lstSv = _db.Sinhviens.ToList();
            //return View(lstSv); // NHỚ ĐỔ DỮ LIỆU RA VIEW DÙM TÔI
            var lstSV = from hv in _db.Sinhviens
                        join lh in _db.Lophocs on hv.Malop equals lh.Malop
                        select new Sinhvien
                        {
                            Masv = hv.Masv,
                            Ten = hv.Ten,
                            Ngaysinh = hv.Ngaysinh,
                            Nganh = hv.Nganh,
                            Malop = hv.Malop,

                            MalopNavigation = lh
                        };
            return View(lstSV.ToList());
        }
        //thằng này chỉ dùng để tạo ra form create thôi
        public IActionResult Create()
        {
            ViewBag.LopHocList = new SelectList(_db.Lophocs, "Malop", "Tenlop");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sinhvien sv)
        {
            _db.Sinhviens.Add(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //sửa
        //thằng này dùng để tạo ra view edit nhưng có dữ liệu của đối tượng cần sửa
        public IActionResult Edit(string id)
        {
            
            var svEdit = _db.Sinhviens.Find(id);
            ViewBag.ListLop = new SelectList(_db.Lophocs, "Malop", "Tenlop",svEdit.Malop);
            return View(svEdit); // nhớ truyền svedt vào để nó đổ dữ liệu
        }
        [HttpPost]
        public IActionResult Edit(Sinhvien sv)
        {
            _db.Sinhviens.Update(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //xem chi tiết
        public IActionResult Details(string id)
        {
            var svDetails = _db.Sinhviens.Find(id);
            return View(svDetails);
        }

        //xóa
        public IActionResult Delete(string id)
        {
            var svDelete = _db.Sinhviens.Find(id);
            _db.Sinhviens.Remove(svDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
