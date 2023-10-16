using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Login.Controllers
{
    public class RegisterController : Controller
    {
        private readonly loginContext _login;
        private readonly IConfiguration _config;

        public RegisterController(loginContext login, IConfiguration config)
        {
            _config = config;
            _login = login;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}

        //[HttpPost]
        //public IActionResult Index(Userschk obj)
        //{
        //    List<Users> lofusers = _login.Users.ToList();
        //    bool f = false;
        //    lofusers.ForEach(u =>
        //    {
        //        if (u.Email == obj.Email && u.Password == obj.Password)
        //        {
        //            f = true;
        //        }
        //    });
        //    if (f)
        //    {
        //        return RedirectToPage("http://localhost:61679/Login/Index");
        //        //return RedirectToAction("welcome", "Index");
        //    }
        //    return RedirectToAction("Home", "Index");
        //}
        //}

//        [AllowAnonymous]
//        [HttpPost]
//        public IActionResult Index([FromBody]Userschk obj)
//        {
//            IActionResult response = Ok("Hello");
//            var user = Authenticate(obj);
//            Str ss = null;
//            if (user != null)
//            {
//                var tokenString = Generate(user);
//                //response = Ok(new { token = tokenString });
//                response = Ok("Hello"); 
//                ss.strg = tokenString;
//            }
//            //return View(ss);
//            return Ok("hello");
//        }

//        private string Generate(Users obj)
//        {
//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            //        var claims = new[]
//            //        {
//            //            new Claim(ClaimTypes.NameIdentifier, obj.UserName),
//            //            new Claim(ClaimTypes.Email, obj.Email),
//            //            new Claim(ClaimTypes.GivenName, obj.Password),
//            //            new Claim(ClaimTypes.Role, obj.IsAdmin),
//            //        };

//            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
//                _config["Jwt:Issuer"], expires: DateTime.Now.AddMinutes(30),
//                signingCredentials: credentials);
//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        public Users Authenticate(Userschk userLogin)
//        {
//            var currentUser = _login.Users.FirstOrDefault(o => o.Email.ToLower() ==
//            userLogin.Email.ToLower() && o.Password == userLogin.Password);

//            if (currentUser != null)
//            {
//                return currentUser;
//            }

//            return null;
//        }
//    }
//}
