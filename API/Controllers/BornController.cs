using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BornController : ControllerBase
    {
        public Data.DataBase DataBase { get; set; }
        public BornController([FromServices]Data.DataBase dataBase)
        {
            DataBase = dataBase;
        }

        // GET: api/<BornController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = DataBase.BornStastitics.GroupBy(BornStastitic => BornStastitic.RegionNumber).Select(group => new { region = group.Key, regionData = group.ToList() });
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
    }
}
