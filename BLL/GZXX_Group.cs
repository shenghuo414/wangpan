using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GZXX_Group
    {
        DAL.GZXX_Group dal = new DAL.GZXX_Group();

        public bool Delete(int groupid) 
        {
            return dal.Delete(groupid);
        }

        public bool GroupHasUser(int groupid) 
        {
            return dal.GroupHasUser(groupid);
        }

        public int GetCount(string where, SqlParameter[] param) 
        {
            return dal.GetCount(where, param);
        }

        public DataTable GetDataTable(string where, int currentSize, int pageSize, SqlParameter[] param)
        {
            return dal.GetDataTable(where, currentSize, pageSize, param);
        }

        public Model.GZXX_Group GetGroupInfo(int groupid) 
        {
            return dal.GetGroupInfo(groupid);
        }

        public bool Add(Model.GZXX_Group model) 
        {
            return dal.Add(model);
        }

        public bool Update(Model.GZXX_Group model) 
        {
            return dal.Update(model);
        }
    }
}
