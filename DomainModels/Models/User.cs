using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models
{
    public class User : Entity
    {
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        
    }
}
