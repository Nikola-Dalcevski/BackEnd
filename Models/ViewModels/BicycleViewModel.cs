using DomainModels.Enums;

namespace Models.ViewModels
{
    public class BicycleViewModel
    {
        public int Id { get; set; }

        public TypeOfBike Type { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        private string _fullName;

        public string Fullname
        {
           get { return _fullName; }
           private set { _fullName = $"{this.Brand} {this.Model}"; }
        }

        public string Brakes { get; set; }

        public string Cassate { get; set; }

        public string Chain { get; set; }

        public string Frame { get; set; }

        public string Handlebar { get; set; }

        public string RearDeraillerur { get; set; }

        public string RearHub { get; set; }

        public string Seat { get; set; }

        public string TireSize { get; set; }

        public string TireInfo { get; set; }

        public string Weight { get; set; }

        public string Cruncset { get; set; }

        public string Fork { get; set; }

        public string Image { get; set; }

        public double Prize { get; set; }

        public bool HasStock { get; set; }

    }

}
