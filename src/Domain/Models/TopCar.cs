namespace Domain.Models
{
    public class TopCar : BaseEntity
    {
        public long CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }

        public long CarBrandModelId { get; set; }
        public CarBrandModel CarBrandModel { get; set; }

        public string CPatterNumber { get; set; }

        public bool HasReservationInNext24Hours { get; set; }

        //public List<Reservation> Reservations { get; set; }
    }
}
