namespace FoodManager.Domain;

public class Ingredient : IIngredient
{
        public required string Name { get; set; }
        public IngredientType IngredientType { get; set; }
        public double Price { get; set;}

        public DateTime? Preremption {get; set;}
}
