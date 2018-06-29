using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaCuocBongDa.Models.Storage;

namespace CaCuocBongDa.Models
{
    public class DataContextDB
    {
        public CaCuocDataContext cacuoc = new CaCuocDataContext();

        public DataContextDB()
        {
            cacuoc.CommandTimeout = 2000;
        }

        public string InsertOrUpdateAcc(string xml, int type)
        {
            try
            {
                cacuoc.CaCuoc_InsertOrUpdate(xml, type);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<CaCuoc_GetTaiKhoanResult> GetTaiKhoan(int id, string user, int type)
        {
            return cacuoc.CaCuoc_GetTaiKhoan(id, user, type).ToList();
        }

        public string InsertOrUpdateMatch(string xml, int type)
        {
            try
            {
                cacuoc.CaCuoc_InsertOrUpdateMatch(xml, type);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}