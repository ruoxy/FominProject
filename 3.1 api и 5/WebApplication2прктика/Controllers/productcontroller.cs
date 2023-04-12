using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2прктика.Models;

namespace WebApplication2прктика.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class productcontroller : ControllerBase
    {
        public практикаContext Context { get; }

        public productcontroller (практикаContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = Context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product? product = Context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("NotFound");
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            Context.Products.Update(product);
            Context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product? product = Context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("Not Found");
            }
            Context.Products.Remove(product);
            Context.SaveChanges();
            return Ok();
        }
    
}
}
