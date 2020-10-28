using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Models
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Field {0} is mandatory")]
        [EmailAddress(ErrorMessage ="Field {0} present invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Passwords are different")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Field {0} is mandatory")]
        [EmailAddress(ErrorMessage = "Field {0} present invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field {0} is mandatory")]
        public string Password { get; set; }
    }

}
