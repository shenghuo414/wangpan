using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class GZXX_Model
    {
        DAL.GZXX_Model dal = new DAL.GZXX_Model();
        public bool EditContent(string tablename, Hashtable ht)
        {
            return dal.EditContent(tablename, ht);
        }
        public bool DeleteContent(string tablename, int infoid)
        {
            return dal.DeleteContent(tablename, infoid);
        }
        public int AddContent(string tablename, Hashtable ht)
        {
            return dal.AddContent(tablename, ht);
        }
        public DataTable GetContent(string tablename, int infoid) 
        {
            return dal.GetContent(tablename, infoid);
        }
    }
}
