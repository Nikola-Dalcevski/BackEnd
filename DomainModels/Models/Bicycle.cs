using DomainModels.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models
{
    public class Bicycle : Entity
    { 

        [Required]
        public TypeOfBike Type { get; set; }

        [Required]
        [MaxLength(50)]
        public Brand Brand { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [MaxLength(100)]
        public string Brakes { get; set; }

        [MaxLength(100)]
        public string Cassate { get; set; }

        [MaxLength(100)]
        public string Chain { get; set; }

        [MaxLength(100)]
        public string Frame { get; set; }

        [MaxLength(100)]
        public string Handlebar { get; set; }

        [MaxLength(100)]
        public string RearDeraillerur { get; set; }

        [MaxLength(100)]
        public string RearHub { get; set; }

        [MaxLength(100)]
        public string Seat { get; set; }

        [MaxLength(100)]
        public string TireSize { get; set; }

        [MaxLength(100)]
        public string TireInfo { get; set; }

        [MaxLength(100)]
        public string Weight { get; set; }

        [MaxLength(100)]
        public string Cruncset { get; set; }

        [MaxLength(100)]
        public string Fork { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Image { get; set; }

        public double Prize { get; set; }

        public virtual ICollection<OrderBicycle> OrdersBicycle { get; set; }

    }
}
