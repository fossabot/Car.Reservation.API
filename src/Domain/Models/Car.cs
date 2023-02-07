namespace Domain.Models
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public string CPatterNumber { get; set; }
        public string Hash { get; set; }

        public bool HasReservationInNext24Hours { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
