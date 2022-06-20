namespace API.Models
{
    public class Data
    {
        public int ID { get; set; }
        public int RegionNumber { get; set; }
        public List<RegionData> RegionData { get; set; }
    }

    public class RegionData
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public int AmountBornFemale { get; set; }
        public int AmountBornMale { get; set; }
    }
}