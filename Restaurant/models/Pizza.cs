using Restaurant.models.enums;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Description { get; set; }
        public StatutPizza StatutPizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public override string ToString()
        {
            var ingredients = Ingredients != null && Ingredients.Any()
                ? string.Join(", ", Ingredients.Select(i => i.Nom))
                : "Aucun ingrédient";

            return $"Pizza {{ Id = {Id}, Nom = {Nom}, Description = {Description}, Statut = {StatutPizza}, Ingredients = [{ingredients}] }}";
        }
    }   
}
