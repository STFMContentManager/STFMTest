using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RCRWrappers
{
    public struct DropDownValue
    {
        private int iId;
        public string sName;

        public int Id
        {
            get { return iId; }
            set { iId = value; }
        }
        public string Name
        {
            get { return sName; }
            set { sName = value; }
        }
    }
}