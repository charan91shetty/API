using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Domain.Model.enums;


namespace Global.Domain.Model
{
   public  class AddressModel
    {
        public int Id { get; set; }

        public AddressType AddressType { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }
    }
}
