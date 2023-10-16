using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Login.Controllers
{
    public class welcomeController : Controller
    {
        private readonly IConfiguration _config;



        private readonly loginContext _login;

        public welcomeController(loginContext login, IConfiguration config)
        {
            _login = login;
            _config = config;
        }

        //        [HttpPost]
        //        public IActionResult Index(Userschk obj)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                var chkpass = Hashing.ToSHA256(obj.Password);
        //                List<Users> lofusers = _login.Users.ToList();
        //                Users send = null;
        //                bool f = false;
        //                lofusers.ForEach(u =>
        //                {
        //                    if (u.Email == obj.Email && u.Password == chkpass)
        //                    {
        //                        f = true;
        //                        send = u;
        //                    }
        //                });
        //                if (f)
        //                {
        //                    if (send.IsAdmin)
        //                    {
        //                        return View(send);
        //                    }
        //                    else
        //                    {
        //                        return RedirectToAction("Index", "IsAdmin");
        //                    }

        //                    //return RedirectToAction("welcome", "Index");
        //                }
        //            }
        //            //return RedirectToAction("Index", "Home");
        //            return RedirectToAction("Index", "Register"); 
        //        }
        //    }
        //}




        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Userschk obj)
        {
            if(obj.Email==""||obj.Password=="")
            {
                return NotFound();
            }
            IActionResult response = Ok();
            var chkpass = Hashing.ToSHA256(obj.Password);
            obj.Password = chkpass;
            var user = Authenticate(obj);
            Str ss = new Str();
            ss.UserName = "";
            ss.strg = "";
            string res = "";
            bool f = false;
            if (user != null)
            {
                var tokenString = Generate(user);
                response = Ok(new { token = tokenString });
                //ss.strg = tokenString;
                res = tokenString;
                f = true;
            }
            HttpContext.Session.SetString("JwtToken", res);

            // Retrieve the token for each request
            var token = HttpContext.Session.GetString("JwtToken");
            if (f)
            {
                if(user.IsAdmin)
                {
                    ss.UserName = user.UserName;
                    ss.strg = res;
                    return View(ss);
                }
                else
                {
                    //ss.UserName = user.UserName;
                    //ss.strg = res;
                    //return View(ss);
                    return RedirectToAction("Index", "IsAdmin");
                }
            }
            //ss.UserName = user.UserName;
            //ss.strg = res;
            //return View(ss);
            return RedirectToAction("Index", "Register");
            //return View(ss);
            //return RedirectToAction("index","welcome",new {res});
            //return Ok(res);
        }

        private string Generate(Users obj)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, obj.UserName),
        new Claim(ClaimTypes.Email, obj.Email),
        // Include other claims as needed, e.g., role claims
        // new Claim(ClaimTypes.Role, "Admin"),
    };

            var token = new JwtSecurityToken(
       _config["Jwt:Issuer"],
       _config["Jwt:Issuer"],
       claims,
       expires: DateTime.Now.AddMinutes(30),
       signingCredentials: credentials
   );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Users Authenticate(Userschk userLogin)
        {

            var currentUser = _login.Users.FirstOrDefault(o => o.Email.ToLower() ==
            userLogin.Email.ToLower() && o.Password == userLogin.Password);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}