using Microsoft.AspNetCore.Mvc;

namespace rabota.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy = null)
        {
            if (sortStrategy == null)
            {
                return Ok(Summaries);
            }
            else if (sortStrategy == 1)
            {
                var sortedList = Summaries.OrderBy(x => x).ToList();
                return Ok(sortedList);
            }
            else if (sortStrategy == -1)
            {
                var sortedList = Summaries.OrderByDescending(x => x).ToList();
                return Ok(sortedList);
            }
            else
            {
                return BadRequest("Ќекорректное значение параметра sortStrategy");
            }
        }

        [HttpGet("{index}")]
        public IActionResult ffff(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("такой индекс неверный");
            {
                return Ok();
            }
        }

        [HttpGet("count")]
        public IActionResult GetCountByName([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("»м€ не может быть пустым");
            }

            int count = Summaries.Count(x => x.Equals(name, StringComparison.OrdinalIgnoreCase));
            return Ok(count);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("такой индекс неверный");
            {
                Summaries.RemoveAt(index);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("такой индекс неверный");
            }
            Summaries[index] = name;
            return Ok();
        }
    }
}