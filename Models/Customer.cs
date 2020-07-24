using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Models
{
    public class Customer
    {
        [Required]
        public int id { get; set; }

        [Required, StringLength(25)]
        public string name { get; set; }

        [Required, StringLength(25)]
        public string lastName { get; set; }
        
        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string email { get; set; }

        [Required, RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string phone { get; set; }

        public DateTime dateBirth { get; set; }
    }
}
