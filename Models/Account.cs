using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopperApi.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set; }
        
        [Required, StringLength(15)]
        public string Login { get; set; }
        
        [Required]
        public string Pwd { get; set; }

        public int CustomerId { get; set; }
    }
}
