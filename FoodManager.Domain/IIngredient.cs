namespace FoodManager.Domain;

public interface IIngredient
{
        string Name { get; set; }
        IngredientType IngredientType { get; set; }
        double Price { get; set;}
        DateTime? Preremption {get; set;}

}
