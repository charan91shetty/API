using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Global.Domain.Model
{
   public class SignInModel
    {
        [Required,EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
