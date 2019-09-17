using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        public string OrderAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderCity { get; set; }
     
        public DateTime? DeleveryDate { get; set; }

        public bool IsActiv { get; set; }

        public bool IsFinished { get; set; }

        //navigation properties
        public virtual ICollection<Bicycle> Bicycles { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


    }
}
