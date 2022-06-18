using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class GZXX_Group
    {
        private int _groupid;
        private string _groupname;
        private string _intro;
        private string _powerlist;

        public int groupid
        {
            set { _groupid = value; }
            get { return _groupid; }
        }

        public string groupname
        {
            set { _groupname = value; }
            get { return _groupname; }
        }


        public string intro
        {
            set { _intro = value; }
            get { return _intro; }
        }


        public string powerlist
        {
            set { _powerlist = value; }
            get { return _powerlist; }
        }

    }
}
