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
        public int Id { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }

        [Required, StringLength(25)]
        public string LastName { get; set; }
        
        [Required, RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        public DateTime DateBirth { get; set; }
    }
}
