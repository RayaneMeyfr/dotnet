using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.models;
using Restaurant.repository;

namespace Restaurant.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly IRepository<Ingredient> _repository;

        public IngredientController(IRepository<Ingredient> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Ingredient> ingredients = _repository.GetAll();
            return Ok(ingredients);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ingredient ingredient)
        {
            _repository.Create(ingredient);
            return CreatedAtAction(nameof(Post), "ingredient Ajouté");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ingredient = _repository.Get(id);
            if (ingredient != null)
            {
                return Ok(ingredient);
            }
            return NotFound(new
            {
                Message = "Ingredient non trouvé"
            });
        }

    }
}
