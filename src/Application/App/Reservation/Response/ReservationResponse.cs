using Application.App.Car.Response;

namespace Application.App.Reservation.Response
{
    public class ReservationResponse
    {
        public long CarId { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime ReservedUntil { get; set; }
        public DateTime CreatedAt { get; set; }

        public CarResponse Car { get; set; }
    }
}
