using Microsoft.AspNetCore.Mvc;
using PMQL.Models;

namespace PMQL.Controllers
{
    public class PersonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            ViewBag.Message = $"ID: {person.PersonId}, Tên: {person.FullName}, Địa chỉ: {person.Address}";
            return View();
        }
    }
}
