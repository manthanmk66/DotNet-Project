using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RidersPoint.Models;
using DAL;
using BLL;


namespace RidersPoint.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet]
        public IActionResult Login()
    {
        return View();
    }
 [HttpPost]
       public IActionResult Login(string emailId ,string password)
    {  
        System.Console.WriteLine("Register IN");
        Login li=new Login(emailId,password);
        DBUser.register(li);
        return View();
    }


        public IActionResult Signup()
    {
        return View();
    }
 [HttpPost]
       public IActionResult Signup(string emailId ,string password)
    {  
        System.Console.WriteLine("Register IN");
        Signup ui=new Signup(emailId,password);
        DBUser.register(ui);
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
