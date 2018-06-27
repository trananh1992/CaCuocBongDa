using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaCuocBongDa.Models.Libraries
{
    public class User
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string HoVaTen { get; set; }
        public bool Checked { get; set; }
    }
}