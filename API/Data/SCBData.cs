using Newtonsoft.Json;
using System.Text;

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
                var data = dataBase.BornStastitics.FirstOrDefault(region => region.ID == item.key[0]);
                if(data != null)
                {
                    var yearData = data.RegionData.FirstOrDefault(year => year.Year == item.key[2]);
                    if(yearData!= null)
                    {
                        _ = item.key[1] == 1 ? yearData.AmountBornFemale = item.values[0] : yearData.AmountBornMale = item.values[0];
                    }
                    else
                    {
                        data.RegionData.Add(item.key[1] == 1 ? new Models.RegionData { Year = item.key[2],  AmountBornFemale = item.values[0]}: new Models.RegionData { Year = item.key[2], AmountBornMale = item.values[0] });
                    }
                    dataBase.SaveChanges();
                }
                else
                {
                    var regionData = (item.key[1] == 1 ? new Models.RegionData { Year = item.key[2], AmountBornFemale = item.values[0] } : new Models.RegionData { Year = item.key[2], AmountBornMale = item.values[0] });
                    dataBase.BornStastitics.Add(new Models.Data { RegionNumber = item.key[0], RegionData = new List<Models.RegionData> { regionData } });
                    dataBase.SaveChanges();
                }
            }
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