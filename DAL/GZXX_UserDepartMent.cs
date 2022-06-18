using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;

namespace DAL
{
    public class GZXX_UserDepartMent
    {
        protected string _menu = string.Empty;
        protected string _newmenu = string.Empty;
        protected DataTable dtAll;
        protected DataTable dtNewAll;
        protected DataTable dtDrpAll;

        public object[] Delete(int departid)
        {
            object[] obj;
            Model.GZXX_UserDepartMent model = new Model.GZXX_UserDepartMent();
            model = getDepartMentInfo(departid);
            SqlParameter[] p1 = new SqlParameter[]{
                new SqlParameter("@departid",SqlDbType.Int)
            };
            p1[0].Value = departid;
            if (model.partentid == 0) {
                obj = new object[] { false, "根组织架构不能删除！" };
                return obj;
            }
            else
            {
                if (DbHelperSQL.Exists("select * from GZXX_UserDepartMent where parentid =@departid", p1))
                {
                    obj = new object[] { false, "请先删除子组织架构！" };
                    return obj;
                }
                else
                {
                    string sql1 = "delete from GZXX_UserDepartMent where departid = @departid";
                    string sql2 = "update GZXX_UserDepartMent set child = child - 1 where departid = @departid";
                    SqlParameter[] p2 = new SqlParameter[] {
                        new SqlParameter("@departid",SqlDbType.Int)
                    };
                    p2[0].Value = model.partentid;

                    List<CommandInfo> list = new List<CommandInfo>();
                    CommandInfo info = new CommandInfo();
                    info.CommandText = sql1;
                    info.Parameters = p1;
                    info.EffentNextType = EffentNextType.ExcuteEffectRows;
                    list.Add(info);
                    CommandInfo info1 = new CommandInfo();
                    info1.CommandText = sql2;
                    info1.Parameters = p2;
                    info1.EffentNextType = EffentNextType.ExcuteEffectRows;
                    list.Add(info1);
                    if (DbHelperSQL.ExecuteSqlTran(list) > 0)
                    {
                        obj = new object[] { true, "操作成功！" };
                        return obj;
                    }
                    else
                    {
                        obj = new object[] { false, "操作失败！" };
                        return obj;
                    }
                }
            }
        }

        public bool Add(Model.GZXX_UserDepartMent model)
        {
            string sql = "insert into GZXX_UserDepartMent([DepartMentName],[DepartMentEname],[ParentID],[Root],[Depth],[OrderID],[ParentIDPath],[Child],[PrevID],[NextID],[ClassDir],[UserName],[AddDate],[Intro],[PhotoUrl],[AdminPurview]) values(@DepartMentName,@DepartMentEname,@ParentID,@Root,@Depth,@OrderID,@ParentIDPath,@Child,@PrevID,@NextID,@ClassDir,@UserName,getdate(),@Intro,@PhotoUrl,@AdminPurview)";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@DepartMentName",SqlDbType.VarChar),
                new SqlParameter("@DepartMentEname",SqlDbType.VarChar),
                new SqlParameter("@ParentID",SqlDbType.Int),
                new SqlParameter("@Root",SqlDbType.Int),
                new SqlParameter("@Depth",SqlDbType.Int),
                new SqlParameter("@OrderID",SqlDbType.Int),
                new SqlParameter("@ParentIDPath",SqlDbType.VarChar),
                new SqlParameter("@Child",SqlDbType.Int),
                new SqlParameter("@PrevID",SqlDbType.Int),
                new SqlParameter("@NextID",SqlDbType.Int),
                new SqlParameter("@ClassDir",SqlDbType.VarChar),
                new SqlParameter("@UserName",SqlDbType.VarChar),
                new SqlParameter("@Intro",SqlDbType.VarChar),
                new SqlParameter("@PhotoUrl",SqlDbType.VarChar),
                new SqlParameter("@AdminPurview",SqlDbType.VarChar)
            };
            param[0].Value = model.departmentname;
            param[1].Value = model.departmentename;
            param[2].Value = model.partentid;
            param[3].Value = model.root;
            param[4].Value = model.depth;
            param[5].Value = model.orderid;
            param[6].Value = model.parentidpath;
            param[7].Value = model.child;
            param[8].Value = model.previd;
            param[9].Value = model.nextid;
            param[10].Value = model.classdir;
            param[11].Value = model.username;
            param[12].Value = model.intro;
            param[13].Value = model.photourl;
            param[14].Value = model.adminpurview;

            string sql1 = "update GZXX_UserDepartMent set child = child + 1 where departid = @departid ";
            SqlParameter[] p2 = new SqlParameter[] {
                new SqlParameter("@departid",SqlDbType.Int)
            };
            p2[0].Value = model.partentid;
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo info = new CommandInfo();
            info.CommandText = sql;
            info.Parameters = param;
            info.EffentNextType = EffentNextType.ExcuteEffectRows;
            list.Add(info);
            CommandInfo info1 = new CommandInfo();
            info1.CommandText = sql1;
            info1.Parameters = p2;
            info1.EffentNextType = EffentNextType.ExcuteEffectRows;
            list.Add(info1);

            if (DbHelperSQL.ExecuteSqlTran(list) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(Model.GZXX_UserDepartMent model) 
        {
            string sql = "update GZXX_UserDepartMent set departmentname = @departmentname,departmentename=@departmentename,orderid=@orderid ,AdminPurview=@AdminPurview,PhotoUrl=@PhotoUrl where departid=@departid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@departmentname",SqlDbType.VarChar),
                new SqlParameter("@departmentename",SqlDbType.VarChar),
                new SqlParameter("@orderid",SqlDbType.Int),
                new SqlParameter("@departid",SqlDbType.Int),
                new SqlParameter("@AdminPurview",SqlDbType.VarChar),
                new SqlParameter("@PhotoUrl",SqlDbType.VarChar)
            };
            param[0].Value = model.departmentname;
            param[1].Value = model.departmentename;
            param[2].Value = model.orderid;
            param[3].Value = model.departid;
            param[4].Value = model.adminpurview;
            param[5].Value = model.photourl;
            if (DBUtility.DbHelperSQL.ExecuteSql(sql, param) > 0)
            {
                return true;
            }
            else 
            {
                return false;            
            }
        }

        public Model.GZXX_UserDepartMent getDepartMentInfo(int departid) 
        {
            Model.GZXX_UserDepartMent model = new Model.GZXX_UserDepartMent();
            string sql = "select * from GZXX_UserDepartMent where departid = @departid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@departid",SqlDbType.Int)
            };
            param[0].Value = departid;
            DataTable dt = DBUtility.DbHelperSQL.Query(sql, param).Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.departid = int.Parse(dt.Rows[0]["departid"].ToString());
                model.child = int.Parse(dt.Rows[0]["child"].ToString());
                model.depth = int.Parse(dt.Rows[0]["depth"].ToString());
                model.nextid = int.Parse(dt.Rows[0]["nextid"].ToString());
                model.orderid = int.Parse(dt.Rows[0]["orderid"].ToString());
                model.partentid = int.Parse(dt.Rows[0]["parentid"].ToString());
                model.previd = int.Parse(dt.Rows[0]["previd"].ToString());
                model.root = int.Parse(dt.Rows[0]["root"].ToString());
                model.username = dt.Rows[0]["username"].ToString();
                model.photourl = dt.Rows[0]["photourl"].ToString();
                model.parentidpath = dt.Rows[0]["parentidpath"].ToString();
                model.intro = dt.Rows[0]["intro"].ToString();
                model.departmentname = dt.Rows[0]["departmentname"].ToString();
                model.departmentename = dt.Rows[0]["departmentename"].ToString();
                model.classdir = dt.Rows[0]["classdir"].ToString();
                model.adminpurview = dt.Rows[0]["adminpurview"].ToString();
                model.adddate = dt.Rows[0]["adddate"].ToString();
                return model;
            }
            else 
            {
                return model;
            }
        }

        public DataTable getDepartMent(int DepartId) 
        {
            ListMenu(DepartId.ToString());
            return dtAll;
        }

        public string ListMenu(string parendId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                DataTable _list = new DataTable();

                string SqlText = string.Format("SELECT * FROM  GZXX_UserDepartMent  order by OrderID");
                _list = DBUtility.DbHelperSQL.Query(SqlText).Tables[0];
                dtAll = _list.Copy();
                dtAll.Rows.Clear();

                string where = string.Format("DepartID={0}", parendId);
                DataRow[] rows = _list.Select(where);
                
                foreach (DataRow dr in rows)
                {

                    string id = dr["DepartID"].ToString();
                    string name = getLine(dr["ParentIDPath"].ToString(), dr["DepartMentName"].ToString(), dr["child"].ToString(), "yes");
                    dtAll.Rows.Add(dr.ItemArray);

                    sb.AppendFormat("<li ID=\"{2}\"><span>{1}\r\n <div class='sub'>" +
                   "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=add&Parentid={2}', '600px', '500px', '添加部门');\">添加子部门</a>" +
                   "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=edit', '600px', '500px', '编辑部门');\">编辑</a>" +
                   "<a onclick=\"deleterow({2});\">删除</a>" +
                   "</div></span>", dr["DepartID"].ToString(), name, id);//href可以写需要的链接地址
                    sb.Append("</li>\r\n");
                    sb.Append(GetSubMenu(id, _list));


                }
                _menu = sb.ToString();
                return _menu;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable getNewDepartMent(int DepartId)
        {
            NewListMenu(DepartId.ToString());
            return dtNewAll;
        }

        public void NewListMenu(string parendId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                DataTable _list = new DataTable();

                string SqlText = string.Format("SELECT * FROM  GZXX_UserDepartMent  order by OrderID");
                _list = DBUtility.DbHelperSQL.Query(SqlText).Tables[0];
                dtNewAll = _list.Copy();
                dtNewAll.Rows.Clear();

                string where = string.Format("DepartID={0}", parendId);
                DataRow[] rows = _list.Select(where);

                foreach (DataRow dr in rows)
                {

                    string id = dr["DepartID"].ToString();
                    string name = getLine(dr["ParentIDPath"].ToString(), dr["DepartMentName"].ToString());
                    dr["DepartMentName"] = name;
                    dtNewAll.Rows.Add(dr.ItemArray);

                   
                    GetNewSubMenu(id, _list);


                }
              
            }
            catch (Exception)
            {
               
            }
        }

        private void GetNewSubMenu(string pid, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            DataRow[] rows = dt.Select("ParentID=" + pid);

            foreach (DataRow dr in rows)
            {

                string id = dr["DepartID"].ToString();
                if (id == pid)
                {
                    dt.Rows.Remove(dr);
                }
                else
                {
                    string name = getLine(dr["ParentIDPath"].ToString(), dr["DepartMentName"].ToString());
                    dr["DepartMentName"] = name;
                    dtNewAll.Rows.Add(dr.ItemArray);

                    GetSubMenu(id, dt);  //递归
                   
                }
            }

            
        }

        private string GetSubMenu(string pid, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            DataRow[] rows = dt.Select("ParentID=" + pid);

            foreach (DataRow dr in rows)
            {

                string id = dr["DepartID"].ToString();
                if (id == pid)
                {
                    dt.Rows.Remove(dr);
                }
                else
                {
                    string name = getLine(dr["ParentIDPath"].ToString(), dr["DepartMentName"].ToString(), dr["child"].ToString(), "yes");
                    dtAll.Rows.Add(dr.ItemArray);
                    sb.AppendFormat("<li ID=\"{2}\"><span> <img src='/sysimg/tree/HR.gif' align='absmiddle' border='0'>{1}\r\n <div class='sub'>" +
                     "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=add&Parentid={2}', '600px', '500px', '添加部门');\">添加子部门</a>" +
                     "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=edit', '600px', '500px', '编辑部门');\">编辑</a>" +
                     "<a onclick=\"deleterow({2});\">删除</a>" +
                     "</div></span>", dr["DepartID"].ToString(), name, id);//href可以写需要的链接地址
                    sb.Append(GetSubMenu(id, dt));  //递归
                    sb.Append("</li>\r\n");
                }
            }

            return sb.ToString();
        }

        public string getLine(string items, string dePartName, string child, string html)
        {
            int count = 0;
            string line = string.Empty;

            string[] item = items.Split(new char[] { ',' });
            count = item.Length;
            for (int i = 0; i < count; i++)
            {
                line = line + "—";
            }

            dePartName = line + dePartName;
            if (child != "0")
            {
                if (html == "yes")
                {
                    dePartName = dePartName + "<span onclick='jd(this)' style='cursor: pointer'>[-]</span>";
                }
                else
                {
                    dePartName = dePartName + "[-]";
                }
            }
            return dePartName;
        }

        public string getLine(string items, string dePartName)
        {
            int count = 0;
            string line = string.Empty;

            string[] item = items.Split(new char[] { ',' });
            count = item.Length;
            for (int i = 1; i < count; i++)
            {
                line = line + "一一";
            }

            dePartName = line + dePartName;
            return dePartName;
        }


        public DataTable getDropDownListDepartMent(int DepartId)
        {
            DropDownListListMenu(DepartId.ToString());
            return dtDrpAll;
        }

        public string DropDownListListMenu(string parendId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                DataTable _list = new DataTable();

                string SqlText = string.Format("SELECT * FROM  GZXX_UserDepartMent  order by OrderID");
                _list = DBUtility.DbHelperSQL.Query(SqlText).Tables[0];
                dtDrpAll = _list.Copy();
                dtDrpAll.Rows.Clear();

                string where = string.Format("DepartID={0}", parendId);
                DataRow[] rows = _list.Select(where);

                foreach (DataRow dr in rows)
                {

                    string id = dr["DepartID"].ToString();
                    string name = getLine(dr["ParentIDPath"].ToString(), dr["DepartMentName"].ToString());
                    dr[1] = name;
                    dtDrpAll.Rows.Add(dr.ItemArray);

                    sb.AppendFormat("<li ID=\"{2}\"><span>{1}\r\n <div class='sub'>" +
                   "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=add&Parentid={2}', '600px', '500px', '添加部门');\">添加子部门</a>" +
                   "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=edit', '600px', '500px', '编辑部门');\">编辑</a>" +
                   "<a onclick=\"deleterow({2});\">删除</a>" +
                   "</div></span>", dr["DepartID"].ToString(), name, id);//href可以写需要的链接地址
                    sb.Append("</li>\r\n");
                    sb.Append(GetDropDownListListSubMenu(id, _list));


                }
                _menu = sb.ToString();
                return _menu;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string GetDropDownListListSubMenu(string pid, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            DataRow[] rows = dt.Select("ParentID=" + pid);

            foreach (DataRow dr in rows)
            {

                string id = dr["DepartID"].ToString();
                if (id == pid)
                {
                    dt.Rows.Remove(dr);
                }
                else
                {
                    string name = getLine(dr["ParentIDPath"].ToString(), dr["DepartMentName"].ToString());
                    dr[1] = name;
                    dtDrpAll.Rows.Add(dr.ItemArray);
                    sb.AppendFormat("<li ID=\"{2}\"><span> <img src='/sysimg/tree/HR.gif' align='absmiddle' border='0'>{1}\r\n <div class='sub'>" +
                     "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=add&Parentid={2}', '600px', '500px', '添加部门');\">添加子部门</a>" +
                     "<a onclick=\"sp('/Page/Public/Config/DepartMent/form/DepartMent.aspx?action=edit', '600px', '500px', '编辑部门');\">编辑</a>" +
                     "<a onclick=\"deleterow({2});\">删除</a>" +
                     "</div></span>", dr["DepartID"].ToString(), name, id);//href可以写需要的链接地址
                    sb.Append(GetDropDownListListSubMenu(id, dt));  //递归
                    sb.Append("</li>\r\n");
                }
            }

            return sb.ToString();
        }

    }
}
