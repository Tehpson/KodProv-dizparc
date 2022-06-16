namespace API.Models
{
    public class BornModel
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public string Region { get; set; }
        public Gender Gender { get; set; }
        public int AmountBorn { get; set; }
    }
    public enum Gender
    {
        Woman = 1,
        man = 2,
    }
}
