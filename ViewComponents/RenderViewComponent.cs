using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewComponents
{
    public class RenderViewComponent: ViewComponent
    {
        private List<MenuItem> ListMenu = new List<MenuItem>();
   
        public RenderViewComponent()
        {
           ListMenu = new List<MenuItem>()
           {
            new MenuItem() { Id=1, Name="Home", Link="/", Icon="fa fa-home" },
            new MenuItem() { Id=2, Name="Students", Link="/Admin/Student/List", Icon="fa fa-users"},
            new MenuItem() { Id=3, Name="Courses", Link="/Admin/Course", Icon="fa fa-book"},
            new MenuItem() { Id=4, Name="About", Link="/Home/About", Icon="fa fa-info"},
           };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", ListMenu);
        }

    }
}
