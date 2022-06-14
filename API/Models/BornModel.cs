namespace API.Models
{
    public class BornModel
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public Region Region { get; set; }
        public string Gender { get; set; }
        public int AmountBorn { get; set; }
    }
}
