using Microsoft.AspNetCore.Mvc;
using PjStudent.Models;
using PjStudent.ViewModels;
using System.Diagnostics;

namespace PjStudent.Controllers
{
	public class HomeController : Controller
	{
		protected PjStudentDBContext _db;

		public HomeController(PjStudentDBContext db)
		{
			_db = db;
		}
		
		public IActionResult Index()
		{
			ViewData["Title"] = "Home Page";
		    var data = _db.AppStudents.ToList();
			return View(data);
		}

		[HttpGet]
		public IActionResult CreateStudent() => View();
		[HttpPost]
		public IActionResult CreateStudent(AppStudentVM stu, [FromServices] IWebHostEnvironment env)
		{
			if (!ModelState.IsValid)
			{
                return RedirectToAction("Index", "Home");
            }

			AppStudent student = new() 
			{
                Id = stu.Id,
                CodeID = stu.CodeID,
                FullName = stu.FullName,
                BirthYear = stu.BirthYear,
                HomeTown = stu.HomeTown,
                PhoneNumber = stu.PhoneNumber,
            };

            student.Avatar = UploadFile(stu.Avatar, env.WebRootPath);
            _db.Add(student);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
		}
        private string UploadFile(IFormFile file, string dir)
        {
            // upload ảnh bìa (CoverImg)
            var fName = file.FileName;
            fName = Path.GetFileNameWithoutExtension(fName)
                    + DateTime.Now.Ticks
                    + Path.GetExtension(fName);

            // Gán giá trị cột CoverImg
            var res = "/upload/" + fName;

            // Tạo đường dẫn tuyệt đối (Ví dụ: E:/Project/wwwroot/upload/xxxx.jpg)
            fName = Path.Combine(dir, "upload", fName);

            // Tạo Stream để lưu file
            var stream = System.IO.File.Create(fName);
            file.CopyTo(stream);
            stream.Dispose(); // Giải phóng bộ nhớ

            return res;
        }
    }
}
