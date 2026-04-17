namespace FoodManager.Domain;

public class Pizza : IFood, IPriceable
{
    private string? _ingredientName;
    public FoodType Type { get => FoodType.PIZZA;}
    public required string Name { get; set; }
    
    public string? Ingredients 
    { 
        get => _ingredientName; 
        set 
        {
            _ingredientName = value;
            
            if (string.IsNullOrWhiteSpace(value))
            {
                IngredientNamesList = new List<string>();
            }
            else
            {
                IngredientNamesList = value.Split(',').ToList();
            }
        } 
    }
    
    public List<string> IngredientNamesList { get; set; } = new List<string>();

    public double CalculatePrice(IEnumerable<IIngredient> IngredientInfos)
    {
        var price = 0.0;
        foreach(var ingredientName in IngredientNamesList)
        {
            var info = IngredientInfos.FirstOrDefault(i => i.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));
            if(info == null)         
                throw new Exception($"L'ingredient' '{ingredientName}' n'est pas présent dans la liste.");
            price += info.Price;            
        }
        return price;
    }  
}
