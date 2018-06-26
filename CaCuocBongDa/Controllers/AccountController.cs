using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaCuocBongDa.Models;
using Newtonsoft.Json.Linq;

namespace CaCuocBongDa.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login(string ReturnUrl)
        {
            if (ReturnUrl == null)
                ViewData["url"] = "/";
            else
                ViewData["url"] = ReturnUrl;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// Set Authentication cho MVC
        /// </summary>
        /// <param name="result">ket qua login tu` jquery. 1. Thanh cong</param>
        /// <param name="user">Ten user</param>
        /// <param name="Checked">Co su dung checked luu lai khong? True, false</param>
        [AllowAnonymous]
        public void SetLogin(int result, string user, bool Checked)
        {
            if (result == 1)
            {
                FormsAuthentication.SetAuthCookie(user.ToLower(), Checked);
            }
        }

        [HttpPost]
        public ActionResult DangKyTaiKhoan(User u)
        {
            return Json(new
            {
                code = 1
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
