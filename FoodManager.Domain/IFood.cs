namespace FoodManager.Domain;

public interface IFood
{
        FoodType Type { get; }        
        string Name { get; set; }
        string? Ingredients { get; set; }
}
