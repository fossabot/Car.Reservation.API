namespace Domain.Models
{
    public class CarBrandModel : BaseEntity
    {
        public string Name { get; set; }
        public DateOnly Year { get; set; }
    }
}
