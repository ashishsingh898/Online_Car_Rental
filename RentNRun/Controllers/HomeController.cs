using Microsoft.AspNetCore.Mvc;
using RentNRunLib;
using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace RentNRun.Controllers
{
    public class HomeController : Controller
    {
        Myclass ob = new Myclass();
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Home()
        {
            return View();
        }
        public ActionResult Cars()
        {
            var result = ob.Cars();
            return View(result);
        }
        public ViewResult Services()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signup ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Signup r)
        {
            var i = ob.Signupmethod(r);
            if (i > 0)
            {
                ViewData["a"] = "New User created successfully";
            }
            else
            {
                ViewData["a"] = "Error occured try after some time";
            }
           ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string t1, string t2)
        {
            HttpContext.Session.SetString("Email",t1);
            var r = ob.Signinmethod(t1, t2);

            if (r > 0)
            {
                Response.Redirect("Cars");

            }
            else
            {
                ViewData["a"] = "In-Valid user";
            }

            return View();
        }

        public ActionResult Signout()
        {
            HttpContext.Session.Clear();
            return View("Signin");
        }

        public ViewResult Contact()
        {
            return View();
        }

        public ViewResult Cart()
        {
            return View();
        }
        public ViewResult Booking()
        {
            return View();
        }
    }
}
