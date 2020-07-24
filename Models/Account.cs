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
        public int id { get; set; }
        
        [Required, StringLength(15)]
        public string login { get; set; }
        
        [Required]
        public string pwd { get; set; }

        public int customerid { get; set; }
    }
}
