using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GZXX_Group
    {
        public Model.GZXX_Group GetGroupInfo(int groupid)
        {
            Model.GZXX_Group model = new Model.GZXX_Group();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@groupid",SqlDbType.Int)
            };
            param[0].Value = groupid;
            DataTable dt = DbHelperSQL.Query("select * from GZXX_Group where groupid=@groupid", param).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.groupid = int.Parse(dt.Rows[0]["groupid"].ToString());
                model.groupname = dt.Rows[0]["groupname"].ToString();
                model.intro = dt.Rows[0]["intro"].ToString();
                model.powerlist = dt.Rows[0]["powerlist"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool Add(Model.GZXX_Group model)
        {
            string sql = "insert into GZXX_Group(GroupName,Intro,PowerList) values(@GroupName,@Intro,@PowerList)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@GroupName",SqlDbType.VarChar),
                new SqlParameter("@Intro",SqlDbType.VarChar),
                new SqlParameter("@PowerList",SqlDbType.Text)
            };
            param[0].Value = model.groupname;
            param[1].Value = model.intro;
            param[2].Value = model.powerlist;
            if (DBUtility.DbHelperSQL.ExecuteSql(sql, param) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Model.GZXX_Group model)
        {
            string sql = "update GZXX_Group set GroupName=@GroupName,Intro=@Intro,PowerList=@PowerList where GroupID = @GroupID";
            SqlParameter[] param = new SqlParameter[] {
               
                new SqlParameter("@GroupName",SqlDbType.VarChar),
                new SqlParameter("@Intro",SqlDbType.VarChar),
                new SqlParameter("@PowerList",SqlDbType.Text),
                new SqlParameter("@GroupID",SqlDbType.Int)
            };
            param[0].Value = model.groupname;
            param[1].Value = model.intro;
            param[2].Value = model.powerlist;
            param[3].Value = model.groupid;
         
            if (DBUtility.DbHelperSQL.ExecuteSql(sql, param) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int groupid)
        {
            string sql = "delete from GZXX_Group where groupid=@groupid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@groupid",SqlDbType.Int)
            };
            param[0].Value = groupid;
            if (DbHelperSQL.ExecuteSql(sql,param) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GroupHasUser(int groupid)
        {
            string sql = "select * from GZXX_Admin where GroupID = @GroupID";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@GroupID",SqlDbType.Int)
            };
            param[0].Value = groupid;
            if (DbHelperSQL.Exists(sql, param)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCount(string where, SqlParameter[] param)
        {
            string sql = "select count(*) from GZXX_Group" + where;
            return int.Parse(DbHelperSQL.GetSingle(sql, param).ToString());
        }

        public DataTable GetDataTable(string where, int currentSize, int pageSize, SqlParameter[] param)
        {
            DataTable dt = DbHelperSQL.Query("select * from GZXX_Group " + where + " order by groupid desc", currentSize, pageSize, param).Tables[0];
            return dt;
        }

    }
}
