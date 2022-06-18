using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GZXX_UserDepartMent
    {
        public static DAL.GZXX_UserDepartMent dal = new DAL.GZXX_UserDepartMent();

        public object[] Delete(int departid) 
        {
            return dal.Delete(departid);
        }

        public bool Update(Model.GZXX_UserDepartMent model) 
        {
            return dal.Update(model);
        }

        public bool Add(Model.GZXX_UserDepartMent model) 
        {
            return dal.Add(model);
        }

        public DataTable getDepartMent(int DepartId) 
        {
            return dal.getDepartMent(DepartId);
        }
        
        public DataTable getNewDepartMent(int DepartId) 
        {
            return dal.getNewDepartMent(DepartId);
        }

        public string getLine(string items,string dePartName,string child,string html)
        {
            return dal.getLine(items,dePartName,child,html);
        }

        public Model.GZXX_UserDepartMent getDepartMentInfo(int departid) 
        {
            return dal.getDepartMentInfo(departid);
        }

        public DataTable getDropDownListDepartMent(int DepartId) 
        {
            return dal.getDropDownListDepartMent(DepartId);
        }
    }
}
