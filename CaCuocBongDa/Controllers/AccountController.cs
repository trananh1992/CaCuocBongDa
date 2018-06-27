using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaCuocBongDa.Models;
using CaCuocBongDa.Models.Libraries;
using Newtonsoft.Json.Linq;

namespace CaCuocBongDa.Controllers
{
    public class AccountController : Controller
    {
        DataContextDB ccDB = new DataContextDB();
        MemberShip mem = new MemberShip();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.Title = "Đăng Nhập";
            if (ReturnUrl == null)
                ViewData["url"] = "/";
            else
                ViewData["url"] = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult KiemTraDangNhap(User user)
        {
            var data = ccDB.GetTaiKhoan(0, user.TenTaiKhoan, 3);
            var code = 0;
            if (data.Count == 0)
            {
                code = 2;
            }
            else
            {
                if (data[0].Password.Trim() == mem.GetMD5Hash(user.TenTaiKhoan, user.MatKhau))
                {
                    if (data[0].IsActive == 1)
                    {
                        FormsAuthentication.SetAuthCookie(user.TenTaiKhoan,user.Checked);
                        code = 1;
                    }
                }
                
            }
            return Json(new
            {
                code
            });
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
        public string DangKyTaiKhoan(User user)
        {
            try
            {
                var xml = "<T UserName='"+user.TenTaiKhoan+"' Password='"+mem.GetMD5Hash(user.TenTaiKhoan,user.MatKhau)+"' Email='"+user.Email+"' FullName='"+user.HoVaTen+"' />";
                ccDB.InsertOrUpdateAcc(xml,1);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
