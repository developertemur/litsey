using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace litsey.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        [MinLength(4)]
        public string Password { get; set; }
    }
}
