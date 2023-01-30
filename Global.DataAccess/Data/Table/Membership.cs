using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global.DataAccess.Data.enums;

namespace Global.DataAccess.Data.Table
{
    public class Membership
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MemberType Type { get; set; }
    }
}
