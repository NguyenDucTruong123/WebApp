using Microsoft.AspNetCore.Mvc;
using  WebApp.Models;
namespace WebApp.Controllers
{
    public class MyNewController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["Name"] = "Jame Bond";
            //ViewBag.age = 30;
            //TempData["City"] = "New York";
            //var u = new User();
            
            //u.ID = 1;
            //u.Name = "Jame Bond";
            //u.Email = "jb@utc.edu.vn";
            //u.Password = "123";
                
            var list = new List<User>();
            var u = new User();
            u.ID = 1;
            u.Name = "Jame Bond";
            u.Email = "JB@lms.utc,edu.vn";
            u.Password = "123";
            var u2 = new User();
            u2.ID = 2;
            u2.Name = "Maria";
            u2.Email = "Mari@lms.utc.edu.vn";
            u2.Password = "456";
            list.Add(u);
            list.Add(u2);
            //Strongly typed Model
            return View(list);
        }

        public IActionResult Sample()
        {
            TempData.Keep();
            return RedirectToAction("Index","Other");
        }

        public IActionResult GetUser(int ID , string Name , string Email , string Password) {             
            var u = new User();
            u.ID = ID;
            u.Name = Name;
            u.Email = Email;
            u.Password = Password;
            return View(u);  //Strongly typed Model
        }
        public IActionResult PostUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostUser([Bind("ID , Name , Email , Password")]User user)
        {
            var u = new User();
            u.ID = user.ID;
            u.Name = user.Name;
            u.Email = user.Email;
            u.Password = user.Password;
            return View("GetUser", u);
        }
    }
}
