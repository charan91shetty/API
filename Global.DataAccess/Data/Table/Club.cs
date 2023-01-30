using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.DataAccess.Data.Table
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClubMemberId { get; set; }
        
       
    }
}
