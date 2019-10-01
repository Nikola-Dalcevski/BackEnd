using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models
{
    public class Order : Entity
    {
  
        [Required]
        public DateTime OrderDate { get; set; }

        [MaxLength(100)]
        [Required]
        public string OrderUserName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
     
        [Required]
        public bool IsActiv { get; set; }

        public bool IsFinishe { get; set; }

        //navigation properties
        public virtual ICollection<OrderBicycle> Bicycles { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


    }
}
