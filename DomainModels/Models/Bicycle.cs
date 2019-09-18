using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels.Models
{
    public class Bicycle : Entity
    { 

        [Required]
        public TypeOfBike Type { get; set; }

        [Required]
        public Brand Brand { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [MaxLength(120)]
        public string FullName { get; set; }

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

        public string Image { get; set; }

        public double Prize { get; set; } 

        

    }
}
