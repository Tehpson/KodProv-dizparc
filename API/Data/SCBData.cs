using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace API.Data
{
    public class SCBData
    {
        public static void getBornData()
        {

            var json = JsonConvert.DeserializeObject(File.ReadAllText(Directory.GetCurrentDirectory() + "/data/SCBRequst.json"));
            using var client = new HttpClient();
            var endpoint = new Uri("https://api.scb.se/OV0104/v1/doris/sv/ssd/START/BE/BE0101/BE0101H/FoddaK");
            var payload = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var resualt = client.PostAsync(endpoint, payload).Result.Content.ReadFromJsonAsync<Root>();
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
