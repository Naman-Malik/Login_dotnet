using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login;
using Login.Models;
using Microsoft.AspNetCore.Mvc;


namespace LOGIN_IN.Controllers
{
    public class LoginController : Controller
    {
        private readonly loginContext _login;

         public LoginController(loginContext login)
        {
             _login = login;
         }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Users obj)
        {
            if(ModelState.IsValid)
            {
                var newpass = Hashing.ToSHA256(obj.Password);
                obj.Password = newpass;
                _login.Users.Add(obj);
                _login.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(obj);


           
            //if (obj.Password.Length <= 5)
            //{
            //    return Ok("not sutiable");
            //}
           
        }
    }
}