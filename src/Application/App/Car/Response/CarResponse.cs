namespace Application.App.Car.Response
{
    public class CarResponse
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CPatterNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    }
}
