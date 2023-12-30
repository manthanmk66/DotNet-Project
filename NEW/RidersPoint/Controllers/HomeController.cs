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



          public IActionResult Welcome()
    {
        return View();
    }


    // [HttpGet]
        public IActionResult Login()
    {
        return View();
    }
 [HttpPost]
       public IActionResult Login(string emailid ,string password)
    {  
         bool isValidLogin = DBUser.Login(emailid, password);

        if (isValidLogin)
        {
            // If login is successful, you can redirect to a different action or view
            return RedirectToAction("Welcome"); // Change "LoggedIn" and "Home" to your desired action and controller names
        }
        else
        {
            // If login fails, you can return the user to the same view with an error message
            ViewBag.ErrorMessage = "Invalid email or password. Please try again.";
            return View("Index");
        }

    

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
