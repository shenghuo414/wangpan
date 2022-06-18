using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GZXX_UserDepartMent
    {
        private int _departid;
        private string _departmentname;
        private string _departmentename;
        private int _partentid;
        private int _root;
        private int _depth;
        private int _orderid;
        private string _parentidpath;
        private int _child;
        private int _previd;
        private int _nextid;
        private string _classdir;
        private string _username;
        private string _adddate;
        private string _intro;
        private string _photourl;
        private string _adminpurview;
        
        public int departid
        {
            set { _departid = value; }
            get { return _departid; }
        }
        public string departmentname
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }
        public string departmentename
        {
            set { _departmentename = value; }
            get { return _departmentename; }
        }
        public int partentid
        {
            set { _partentid = value; }
            get { return _partentid; }
        }
        public int root
        {
            set { _root = value; }
            get { return _root; }
        }
        public int depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        public int orderid
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        public string parentidpath
        {
            set { _parentidpath = value; }
            get { return _parentidpath; }
        }
        public int child
        {
            set { _child = value; }
            get { return _child; }
        }
        public int previd
        {
            set { _previd = value; }
            get { return _previd; }
        }
        public int nextid
        {
            set { _nextid = value; }
            get { return _nextid; }
        }
        public string classdir
        {
            set { _classdir = value; }
            get { return _classdir; }
        }
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        public string adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        public string intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        public string photourl
        {
            set { _photourl = value; }
            get { return _photourl; }
        }
        public string adminpurview
        {
            set { _adminpurview = value; }
            get { return _adminpurview; }
        }
    }
}
