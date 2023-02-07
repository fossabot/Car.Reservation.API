namespace API.Controllers.Requests
{
    public class AddReservationRequest
    {
        public long? CarId { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime ReservedUntil { get; set; }
    }
}
