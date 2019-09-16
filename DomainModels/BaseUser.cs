using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModels.Models
{
    
    public abstract class BaseUser : Entity
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

       
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
   
    }
}
