using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace API.Data
{
    public class SCBData
    {
        public static void init(DataBase dataBase)
        {
            Console.WriteLine("Check if data need to be added to DB");
            var standardDataList = dataBase.BornStastitics.Take(2).ToList();
            if (standardDataList.Count == 0)
            {
                Console.WriteLine("Adding Data");
                getBornData(dataBase);
            }
        }
        private static void getBornData(DataBase dataBase)
        {
            var json = JsonConvert.DeserializeObject(File.ReadAllText(Directory.GetCurrentDirectory() + "/data/SCBRequst.json"));
            using var client = new HttpClient();
            var endpoint = new Uri("https://api.scb.se/OV0104/v1/doris/sv/ssd/START/BE/BE0101/BE0101H/FoddaK");
            var payload = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var resualt = client.PostAsync(endpoint, payload).Result.Content.ReadFromJsonAsync<Root>();
            foreach (var item in resualt.Result.data)
            {
                var model = new Models.BornModel { RegionNumber = item.key[0], Gender = item.key[1] == 1 ? Models.Gender.Woman : Models.Gender.man, Year = item.key[2], AmountBorn = item.values[0] };
                dataBase.Add(model);
            }
            dataBase.SaveChanges();
        }
    }

    public class Root
    {
        public Data[] data { get; set; }
    }

    public class Data
    {
        public int[] key { get; set; }
        public int[] values { get; set; }
    }
}