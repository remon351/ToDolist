using Microsoft.AspNetCore.Mvc;
using ToDolist.data;
using ToDolist.Models;

namespace ToDolist.Controllers
{
    public class TodoitemController : Controller
    {
        ApplicationDbContext context= new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult create(string Name)
        {
            //context.lists.Add(list);
            //context.SaveChanges();

            Response.Cookies.Append("name", Name);


            return RedirectToAction(nameof(create));
            
        }
        public IActionResult addToDoList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addToDoList(list list)
        {
            context.lists.Add(list);
            context.SaveChanges();
            return RedirectToAction(nameof(create));
        }
        public IActionResult edit(int id)
        {
            var getvalues = context.lists.Find(id);
            return View(getvalues);
        }
    }
}
