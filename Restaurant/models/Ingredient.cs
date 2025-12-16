using System.ComponentModel.DataAnnotations;

namespace Restaurant.models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Ingredient {{ Id = {Id}, Nom = {Nom}, Description = {Description} }}";
        }
    }
}
