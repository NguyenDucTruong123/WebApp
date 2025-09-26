using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
namespace WebApp.Controllers

{
    [Route("Admin/[controller]")]
    public class StudentController : Controller
    {
        private List<Student> listStudent = new List<Student>();
        public StudentController()
        {
            listStudent = new List<Student>()
            {
                new Student() { Id = 101,
                    Name = "Hải Nam", 
                    Branch = Branch.IT,
                    Gender = Gender.Male, 
                    IsRegular = true, 
                    Password="123" ,
                    Address = "A1-2018",
                    Email = "nam@g.com" , 
                    Avatar="https://robohash.org/phamhuong.png?size=150x150" , 
                    DateOfBorth=new DateTime(2003,5,23)},

        //new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
        //    Gender = Gender.Female, IsRegular = true,Password="123",
        //    Address = "A1-2019", Email = "tu@g.com",Avatar=""},

        //new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
        //    Gender = Gender.Male, IsRegular = false,Password="123",
        //    Address = "A1-2020", Email = "phong@g.com" ,Avatar=""},

        //new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
        //    Gender = Gender.Female, IsRegular = false, Password="123",
        //    Address = "A1-2021", Email = "mai@g.com", Avatar="" }

            };
         }
        [Route("add")]
        [HttpGet]
        public IActionResult Create()
        {
            // Lấy danh sách các giá trị Gender để hiển thị radio button trên form
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            // Lấy danh sách các giá trị Branch để hiển thị select-option trên form
            // Để hiển thị select-option trên View cần dùng List<SelectListItem>
            ViewBag.AllBranches = new List<SelectListItem>()
    {
        new SelectListItem { Text = "IT", Value = "1" },
        new SelectListItem { Text = "BE", Value = "2" },
        new SelectListItem { Text = "CE", Value = "3" },
        new SelectListItem { Text = "EE", Value = "4" }
    };
            return View();
        }
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentForm s)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

                if (s.Avatar == null || s.Avatar.Length == 0)
            {
                return BadRequest("Avatar khong hop le");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileName = Path.GetFileName(s.Avatar.FileName);
            var filePath = Path.Combine(path, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await s.Avatar.CopyToAsync(stream);
            }
            var avatarUrl = $"{Request.Scheme}://{Request.Host}/images/{fileName}";
            var student = new Student
            {
                Id = listStudent.Last<Student>().Id + 1,
                Name = s.Name,
                Email = s.Email,
                Password = s.Password,
                Avatar = avatarUrl,
                Branch = s.Branch,
                Score = s.Score,
                DateOfBorth = s.DateOfBorth,
                Address = s.Address
            };
                listStudent.Add(student);
                return View("Index", listStudent);
        }
        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudent);
        }
    }
}
