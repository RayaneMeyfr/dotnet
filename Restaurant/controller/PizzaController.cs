using Microsoft.AspNetCore.Mvc;
using Restaurant.models;
using Restaurant.repository;

namespace Restaurant.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IRepository<Pizza> _repository;

        public PizzaController(IRepository<Pizza> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pizza> pizzas = _repository.GetAll();
            return Ok(pizzas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pizza pizza)
        {
            _repository.Create(pizza);
            return CreatedAtAction(nameof(Post), "pizza Ajouté");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pizza = _repository.Get(id);
            if (pizza != null)
            {
                return Ok(pizza);
            }
            return NotFound(new
            {
                Message = "Pizza non trouvé"
            });
        }
    }
}
