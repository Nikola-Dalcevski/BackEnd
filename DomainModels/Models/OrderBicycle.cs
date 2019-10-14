using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    public class OrderBicycle
    {
        [Key, Column(Order = 1)]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        [Key, Column(Order = 2)]
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; }
    }
}
