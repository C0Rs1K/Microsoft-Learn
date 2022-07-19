using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Services;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
            PizzaService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }
        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (pizza.Id != id)
            {
                return BadRequest();
            }

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
            {
                return NotFound();
            }
            
            PizzaService.Update(pizza);
            return NoContent();
        }
        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza is null)
            {
                return NotFound();
            }
            
            PizzaService.Delete(id);
            
            return NoContent();
        }
    }
}
