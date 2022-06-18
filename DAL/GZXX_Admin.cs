using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;

namespace DAL
{
    public class GZXX_Admin
    {
        public bool UpdateLocked(Model.GZXX_Admin model) 
        {
            string sql = "update GZXX_Admin set Locked = @Locked where LoginName = @LoginName";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@Locked",SqlDbType.Int),
                new SqlParameter("@LoginName",SqlDbType.VarChar)
            };
            param[0].Value = model.Locked;
            param[1].Value = model.LoginName;
            if (DbHelperSQL.ExecuteSql(sql, param) > 0) { return true; }
            else { return false; }
        }

        public bool UpdatePassWord(Model.GZXX_Admin model) 
        {
            string sql = "update GZXX_Admin set PassWord = @PassWord where LoginName = @LoginName";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@PassWord",SqlDbType.VarChar),
                new SqlParameter("@LoginName",SqlDbType.VarChar)
            };
            param[0].Value = model.PassWord;
            param[1].Value = model.LoginName;
            if (DbHelperSQL.ExecuteSql(sql, param) > 0) { return true; }
            else { return false; }
        }

        public bool UpdateLoginInfo(Model.GZXX_Admin model) 
        {
            string sql = "update GZXX_Admin set LastLoginIP=@LastLoginIP,LastLoginTime=getdate() where LoginName = @LoginName";
            SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@LastLoginIP",SqlDbType.VarChar),
            new SqlParameter("@LoginName",SqlDbType.VarChar)
            };
            param[0].Value = model.LastLoginIP;
            param[1].Value = model.LoginName;
            if (DbHelperSQL.ExecuteSql(sql, param) > 0) { return true; }
            else { return false; }
        }

        public bool CheckLogin(string LoginName, string PassWord) 
        {
            string sql = "select * from GZXX_Admin where LoginName = @LoginName and PassWord = @PassWord ";
            SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@LoginName",SqlDbType.VarChar),
            new SqlParameter("@PassWord",SqlDbType.VarChar)
            };
            param[0].Value = LoginName;
            param[1].Value = PassWord;
            if (DbHelperSQL.Exists(sql, param))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool HasAdmin(string LoginName) 
        {
            string sql = "select * from GZXX_Admin where LoginName = @LoginName";
            SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@LoginName",SqlDbType.VarChar)
            };
            param[0].Value = LoginName;
            if (DbHelperSQL.Exists(sql, param))
            {
                return true;
            }
            else { return false; }
        }

        public bool Update(Model.GZXX_Admin model)
        {
            string sql = "Update GZXX_Admin set PassWord = @PassWord,RealName = @RealName,Locked = @Locked,PowerList=@PowerList,UserFace=@UserFace,DepartId=@DepartId,GroupID=@GroupID where LoginName = @LoginName";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@PassWord",SqlDbType.VarChar),
                new SqlParameter("@RealName",SqlDbType.VarChar),
                new SqlParameter("@Locked",SqlDbType.Int),
                new SqlParameter("@PowerList",SqlDbType.VarChar),
                new SqlParameter("@UserFace",SqlDbType.VarChar),
                new SqlParameter("@DepartID",SqlDbType.Int),
                new SqlParameter("@GroupID",SqlDbType.Int),
                new SqlParameter("@LoginName",SqlDbType.VarChar)
            };
            param[0].Value = model.PassWord;
            param[1].Value = model.RealName;
            param[2].Value = model.Locked;
            param[3].Value = model.PowerList;
            param[4].Value = model.UserFace;
            param[5].Value = model.DepartID;
            param[6].Value = model.GroupID;
            param[7].Value = model.LoginName;

            if (DBUtility.DbHelperSQL.ExecuteSql(sql, param) > 0)
            {
                return true;
            }
            else { return false; }
        }

        public bool Add(Model.GZXX_Admin model) 
        {
            string sql = "insert into GZXX_Admin values(@LoginName,@PassWord,@RealName,getdate(),@LastLoginIP,getdate(),@Locked,@PowerList,@UserFace,@DepartId,@GroupID)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginName",SqlDbType.VarChar),
                new SqlParameter("@PassWord",SqlDbType.VarChar),
                new SqlParameter("@RealName",SqlDbType.VarChar),
                new SqlParameter("@LastLoginIP",SqlDbType.VarChar),
                new SqlParameter("@Locked",SqlDbType.Int),
                new SqlParameter("@PowerList",SqlDbType.VarChar),
                new SqlParameter("@UserFace",SqlDbType.VarChar),
                new SqlParameter("@DepartID",SqlDbType.Int),
                new SqlParameter("@GroupID",SqlDbType.Int)
            };
            param[0].Value = model.LoginName;
            param[1].Value = model.PassWord;
            param[2].Value = model.RealName;
            param[3].Value = model.LastLoginIP;
            param[4].Value = model.Locked;
            param[5].Value = model.PowerList;
            param[6].Value = model.UserFace;
            param[7].Value = model.DepartID;
            param[8].Value = model.GroupID;

            if (DBUtility.DbHelperSQL.ExecuteSql(sql, param) > 0) 
            {
                return true;
            }
            else { return false; }
        }

        public bool Delete(int ID) 
        {
            string sql = "delete from GZXX_Admin where ID = @ID";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            param[0].Value = ID;
            if (DBUtility.DbHelperSQL.ExecuteSql(sql, param) > 0) 
            { return true; } 
            else { return false; }
        }

        public int GetCount(string where) 
        {
            string sql = "select count(*) from GZXX_Admin "+where;
            return int.Parse(DBUtility.DbHelperSQL.GetSingle(sql).ToString());
        }

        public DataTable GetDataTable(string where, int currentSize, int pageSize) 
        {
            DataTable dt = DbHelperSQL.Query("select GZXX_Admin.*,GZXX_UserDepartMent.DepartMentName,(select GroupName from GZXX_Group where GZXX_Group.GroupID = GZXX_Admin.GroupID) as GroupName from GZXX_Admin left join GZXX_UserDepartMent on GZXX_Admin.DepartID = GZXX_UserDepartMent.DepartID  " + where, currentSize, pageSize).Tables[0];
            return dt;
        }

        public Model.GZXX_Admin GetAdminInfo(string LoginName) 
        {
            string sql = "select * from GZXX_Admin where LoginName = @LoginName";
            SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@LoginName",SqlDbType.VarChar)
            };
            param[0].Value = LoginName;
            DataTable dt = DbHelperSQL.Query(sql, param).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Model.GZXX_Admin model = new Model.GZXX_Admin();
                model.AddDate = DateTime.Parse(dt.Rows[0]["AddDate"].ToString());
                model.DepartID = int.Parse(dt.Rows[0]["DepartID"].ToString());
                model.GroupID = int.Parse(dt.Rows[0]["GroupID"].ToString());
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.LastLoginIP = dt.Rows[0]["LastLoginIP"].ToString();
                model.LastLoginTime = DateTime.Parse(dt.Rows[0]["LastLoginTime"].ToString());
                model.Locked = int.Parse(dt.Rows[0]["Locked"].ToString());
                model.LoginName = dt.Rows[0]["LoginName"].ToString();
                model.PassWord = dt.Rows[0]["PassWord"].ToString();
                model.PowerList = dt.Rows[0]["PowerList"].ToString();
                model.RealName = dt.Rows[0]["RealName"].ToString();
                model.UserFace = dt.Rows[0]["UserFace"].ToString();
                return model;
            }
            else { return null; }
        }
    }
}
