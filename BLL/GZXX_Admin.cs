using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GZXX_Admin
    {
        DAL.GZXX_Admin dal = new DAL.GZXX_Admin();

        public bool UpdateLocked(Model.GZXX_Admin model)
        {
            return dal.UpdateLocked(model);
        }

        public bool UpdatePassWord(Model.GZXX_Admin model) 
        {
            return dal.UpdatePassWord(model);
        }

        public bool UpdateLoginInfo(Model.GZXX_Admin model) 
        {
            return dal.UpdateLoginInfo(model);
        }

        public bool CheckLogin(string LoginName, string PassWord) 
        {
            return dal.CheckLogin(LoginName, PassWord);
        }

        public Model.GZXX_Admin GetAdminInfo(string LoginName) 
        {
            return dal.GetAdminInfo(LoginName);
        }

        public bool HasAdmin(string LoginName) 
        {
            return dal.HasAdmin(LoginName);
        }

        public bool Add(Model.GZXX_Admin model) 
        {
            return dal.Add(model);
        }

        public bool Delete(int ID) 
        {
            return dal.Delete(ID);
        }

        public int GetCount(string where) 
        {
            return dal.GetCount(where);
        }

        public DataTable GetDataTable(string where, int currentSize, int pageSize) 
        {
            return dal.GetDataTable(where, currentSize, pageSize);
        }

        public bool Update(Model.GZXX_Admin model) 
        {
            return dal.Update(model);
        }
    }
}
