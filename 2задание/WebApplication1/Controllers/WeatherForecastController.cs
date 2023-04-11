using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("index")]
        public IActionResult Get(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("find-by-name")]
        public IActionResult GetName( string name)
        {
           int x = 0;
            foreach(string s in Summaries)
            {
                if (s == name)
                    x += 1;
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
            {
                return Ok();
            }
            else if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Ok();
            }
            else if (sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Ok();
            }
            else return BadRequest("������������ �������� ��������� sortStrategy");
        }

    }
}