using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GZXX_Admin
    {
        private int _id;
        private int _locked;
        private DateTime _adddate;
        private DateTime _lastlogintime;
        private string _password;
        private string _lastloginip;
        private string _loginname;
        private string _realname;
        private string _powerlist;
        private string _userface;
        private int _departid;
        private int _groupid;

        public string UserFace
        {
            set { _userface = value; }
            get { return _userface; }
        }
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        public string PowerList
        {
            set { _powerlist = value; }
            get { return _powerlist; }
        }
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        public int ID 
        {
            set { _id = value; }
            get { return _id; }
        }
        public int DepartID
        {
            set { _departid = value; }
            get { return _departid; }
        }
        public int GroupID
        {
            set { _groupid = value; }
            get { return _groupid; }
        }
        public int Locked
        {
            set { _locked = value; }
            get { return _locked; }
        }
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
    }
}
