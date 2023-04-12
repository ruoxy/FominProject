using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2прктика.Models;

namespace WebApplication2прктика.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class filtercontroller : ControllerBase
    {
        public практикаContext Context { get; }

        public filtercontroller(практикаContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Filterr> filterrs = Context.Filterrs.ToList();
            return Ok(filterrs);
        }

       



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Filterr? filterr = Context.Filterrs.Where(x => x.CategoryId == id).FirstOrDefault();
            if (filterr == null)
            {
                return BadRequest("NotFound");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Filterr filterr)
        {
            Context.Filterrs.Add(filterr);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Filterr filterr)
        {
            Context.Filterrs.Update(filterr);
            Context.SaveChanges();
            return Ok(filterr);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Filterr? filterr = Context.Filterrs.Where(x => x.CategoryId == id).FirstOrDefault();
            if (filterr == null)
            {
                return BadRequest("Not Found");
            }
            Context.Filterrs.Remove(filterr);
            Context.SaveChanges();
            return Ok();
        }

        [HttpGet("Sort")]
        public IActionResult GetAl(int? price)
        {
            if (!price.HasValue)
            {
                return Ok(price);
            }
            else if (price.Value == 1)
            {
                price.Sort();
                return Ok(price);
            }
            else if (price.Value == -1)
            {
                price.Sort();
                price.Reverse();
                return Ok(price);
            }
            else
            {
                return BadRequest("не то значение");
            }
        }
    }
}
