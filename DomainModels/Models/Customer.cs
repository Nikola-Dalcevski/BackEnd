using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModels.Models
{
    public class Customer : BaseUser
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
     
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
