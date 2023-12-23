using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SysManageCRUD.Models;
using System.Text;
using XSystem.Security.Cryptography;

namespace SysManageCRUD.Areas.Front.Controllers
{
    [Area("Front")]
    public class AccessController : Controller
    {
        private readonly IDbConnection _bd;

        public AccessController(IConfiguration configuration)
        {
            _bd = new SqlConnection(configuration.GetConnectionString("ConexionSQLServerDB"));
        }

        public IActionResult Access()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserLogin(User user)
        {
            if (ModelState.IsValid)
            {
                var sql = "SELECT * FROM User Where Login=@Login AND Password=@Password";
                var Password = GetMD5(user.Password);
                var validate = _bd.Query<User>(sql, new
                {
                    user.Login,
                    Password

                });

                if (validate.Count() == 1)
                {
                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Name,user.Login)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Login");
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Start");
                }
                else
                {
                    TempData["messageconfirmation"] = "Incorrect login credentials";
                    return RedirectToAction("Access", "Access");

                }
            }
            else
            {
                TempData["messageconfirmation"] = "Some required fields are empty\"";
                return RedirectToAction("Access", "Access");

            }
        }

        public static string GetMD5(string valor)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = Encoding.UTF8.GetBytes(valor);
                data = md5.ComputeHash(data);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2").ToLower());
                }

                return stringBuilder.ToString();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
