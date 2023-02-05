namespace Domain.Models
{
    public class Reservation : BaseEntity
    {
        public DateTime ReservedAt { get; set; }
        public DateTime ReservedUntil { get; set; }
        public TimeSpan Range { get; set; }

        public long CarId { get; set; }
        public Car Car { get; set; }
    }
}
