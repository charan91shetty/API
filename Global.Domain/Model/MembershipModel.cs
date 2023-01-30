﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Domain.Model.enums;

namespace Global.Domain.Model
{
    public class MembershipModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MemberType Type { get; set; }
    }
}
