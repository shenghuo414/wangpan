using DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GZXX_Model
    {

        public bool EditContent(string TableName, Hashtable ht)
        {
            
            string s = "update " + TableName + " set ";
            List<SqlParameter> p = new List<SqlParameter>();
            int flag = 0;
            foreach (DictionaryEntry de in ht)
            {
                if (flag == 0)
                {
                    s += de.Key.ToString() + "=@" + de.Key.ToString();
                }
                else
                {
                    s += "," + de.Key.ToString() + "=@" + de.Key.ToString();
                }
                flag++;
                p.Add(new SqlParameter("@" + de.Key.ToString(), de.Value.ToString()));
            }
            s += " where infoid=@infoid";
            SqlParameter[] parameters = p.ToArray();
            List<CommandInfo> list = new List<CommandInfo>();
            CommandInfo info2 = new CommandInfo();
            info2.CommandText = s;
            info2.EffentNextType = EffentNextType.ExcuteEffectRows;
            info2.Parameters = parameters;
            list.Add(info2);
            if (DbHelperSQL.ExecuteSqlTran(list) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

 
        public bool DeleteContent(string tablename,int infoid)
        {
            if (DbHelperSQL.ExecuteSql("delete from "+tablename +" where infoid = "+infoid) > 0) { return true; }
            else { return false; }
        }
        public DataTable GetContent(string tablename, int infoid) 
        {
            string sql = "select * from " + tablename + " where infoid=@infoid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@infoid",SqlDbType.Int)
            };
            param[0].Value = infoid;
            return DbHelperSQL.Query(sql, param).Tables[0];
        }

        public int AddContent(string tablename, Hashtable ht) 
        {
            string sql = "insert into GZXX_InfoList(channelid,classid,title) values(@channelid,@classid,@title)select @@identity";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@channelid",SqlDbType.Int),
                new SqlParameter("@classid",SqlDbType.Int),
                new SqlParameter("@title",SqlDbType.NVarChar)
            };
            param[0].Value = ht["channelid"];
            param[1].Value = ht["ClassID"];
            param[2].Value = ht["Title"];
            int infoid = DbHelperSQL.ExecuteSqlReturnID(sql, param);
            if (infoid > 0)
            {
                string s = "insert into " + tablename + " (infoid";
                string v = " values(@infoid";
                List<SqlParameter> p = new List<SqlParameter>();
                //SqlParameter[] p = new SqlParameter[]{};
                p.Add(new SqlParameter("@infoid", infoid));
                int flag = 0;
                foreach (DictionaryEntry de in ht)
                {
                    flag++;
                    s += "," + de.Key.ToString();
                    v += ",@" + de.Key.ToString();
                    p.Add(new SqlParameter("@" + de.Key.ToString(), de.Value.ToString()));
                }
                s += ")";
                v += ")";
                SqlParameter[] parameters = p.ToArray();
                if (DbHelperSQL.ExecuteSql(s + v, parameters) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
