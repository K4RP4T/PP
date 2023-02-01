using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HomeController : Controller
{
    // 
    // GET: /Home/
    public IActionResult Index()
    {
        return View();
    }
}